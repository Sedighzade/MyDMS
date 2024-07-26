using PNB.Helpers;
using PNB.SAS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNB.SAS.Archive
{
    public partial class frmTest : Form
    {
        int firstItem;
        private ListViewItem[] myCache;
        List<Archive.SlotData> keyPairs;
        string folder = "";//@"E:\PNB\Projects & Tech. Docs\Projects\HMI\MyDMS\SASApp\bin\Debug\Data\SMV";
        List<long> ieds = new List<long>();
        public frmTest()
        {
            InitializeComponent();

            IntPtr hh = this.Handle;
            folder = Configuration.AppPath + "\\Data\\SMV";
            TopMost = true;
            tsbtnAoT.Checked = TopMost;
            ieds.Add(1001);
            ieds.Add(1002);
            ieds.Add(1003);

            //lvw2.VirtualMode = true;
            lvw2.RetrieveVirtualItem += delegate (object sender, RetrieveVirtualItemEventArgs e)
            {
                //Caching is not required but improves performance on large sets. 
                //To leave out caching, don't connect the CacheVirtualItems event  
                //and make sure myCache is null. 

                try
                {
                    //check to see if the requested item is currently in the cache 
                    if (myCache != null && e.ItemIndex >= firstItem && e.ItemIndex < firstItem + myCache.Length)
                    {
                        //A cache hit, so get the ListViewItem from the cache instead of making a new one.
                        e.Item = myCache[e.ItemIndex - firstItem];
                    }
                    else
                    {
                        //A cache miss, so create a new ListViewItem and pass it back. 
                        e.Item = new ListViewItem();
                        e.Item.SubItems.Add( Util.ConvertDateTimeToFileName(keyPairs[e.ItemIndex].Time, false).ToString());
                        e.Item.SubItems.Add(keyPairs[e.ItemIndex].SlotSize.ToString());

                    }
                }
                catch (Exception ee)
                {

                }
            };
            lvw2.CacheVirtualItems += delegate (object sender, CacheVirtualItemsEventArgs e)
            {
                //We've gotten a request to refresh the cache. 
                //First check if it's really neccesary. 
                if (myCache != null && e.StartIndex >= firstItem && e.EndIndex <= firstItem + myCache.Length)
                {
                    //If the newly requested cache is a subset of the old cache,  
                    //no need to rebuild everything, so do nothing. 
                    return;
                }

                //Now we need to rebuild the cache.
                firstItem = e.StartIndex;
                int length = e.EndIndex - e.StartIndex + 1; //indexes are inclusive
                myCache = new ListViewItem[length];

                //Fill the cache with the appropriate ListViewItems.               
                for (int i = 0; i < length; i++)
                {
                    string h = Util.ConvertDateTimeToFileName(keyPairs[i + firstItem].Time, false);
                    myCache[i] = new ListViewItem();
                    myCache[i].SubItems.Add(Util.ConvertDateTimeToFileName(keyPairs[i].Time, false).ToString());
                    myCache[i].SubItems.Add(keyPairs[i].SlotSize.ToString());
                }
            };
            lvw2.SearchForVirtualItem += delegate (object sender, SearchForVirtualItemEventArgs e)
            {


            };

            lvw1.SelectedIndexChanged += delegate
            {
                if (lvw1.SelectedItems.Count == 0) return;
                Archive.SMVHeader h1 = lvw1.SelectedItems[0].Tag as Archive.SMVHeader;
                Archive.SMVKeySection keys = new Archive.SMVKeySection(h1.IED);
                keyPairs = keys.LoadKeysFromFile();
                lvw2.VirtualListSize = keyPairs.Count;
                List<ListViewItem> items = new List<ListViewItem>(keyPairs.Count);
                keyPairs.ForEach(x =>
                {
                    ListViewItem ii = new ListViewItem((items.Count + 1).ToString());
                    ii.SubItems.Add( Util.ConvertDateTimeToFileName(x.Time, false).ToString());
                    ii.SubItems.Add(string.Format("{0} ({1}) ", x.SlotSize, x.SlotSize / 24));
                    items.Add(ii);
                });
                lvw2.BeginUpdate();
                lvw2.Items.AddRange(items.ToArray());
                lvw2.EndUpdate();
            };

            tsbtnReload_Click(null, null);
        }

        private void DoParseFile(long ied)
        {
            Archive.SMVHeader h1 = null;
            ListViewItem item = null;
            try
            {
                h1 = Archive.SMVHeader.Deserialize(ied);
                h1.FileName = Archive.GetSMVFileName(ied);
                item = new ListViewItem();
                item.Tag = h1;

                item.SubItems.Add(h1.Version.ToString());
                item.SubItems.Add(h1.IED.ToString());
                item.SubItems.Add( Util.ConvertDateTimeToFileName(h1.TOC, false));
                item.SubItems.Add( Util.ConvertDateTimeToFileName(h1.LastSaveTime, false));
                item.SubItems.Add(h1.SlotCount.ToString());
                Invoke((MethodInvoker)delegate { lvw1.Items.Add(item); });
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbtnOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", Configuration.GetSMVDataDir());
        }

        private void tsbtnDeleteFiles_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(folder);
            foreach (string fn in files)
                File.Delete(fn);

            lvw1.Items.Clear();
            lvw2.Items.Clear();
        }

        private void tsbtnFill_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                List<PollRoundData> prds = new List<PollRoundData>();
                Archive arc = new Archive(ieds);
                arc.Init();
                Random r = new Random();


                DateTime now = DateTime.Now;

                foreach (long ied in ieds)
                {
                    int size = r.Next(1, 50);
                    PollRoundData prd = new PollRoundData();
                    prd.IED = ied;
                    prd.Time = DateTime.Now.Ticks;
                    prds.Add(prd);
                    for (int j = 0; j < size; j++)
                    {
                        DataTag dt = new ENS() { Value = r.NextDouble(), IED = ied, Time = now.AddSeconds(5).Ticks };
                        dt.InfoID = now.AddSeconds(5).Ticks;
                        prd.Data.Add(dt);
                    }
                }
                arc.BeginSMVSaveData(prds);
                Invoke((MethodInvoker)delegate
                {
                    //lvw2.VirtualListSize = 0;
                    lvw2.Items.Clear();
                    tsbtnReload_Click(null, null);
                });

            });
        }

        private void tsbtnCreateFile_Click(object sender, EventArgs e)
        {
            Archive arc = new SAS.Archive.Archive(ieds);
            long ied = long.Parse(tstxtIED.Text);
            Archive.SMVFile.CreateOrOpenSMVFile(ied);
            tsbtnReload_Click(null, null);
            MessageBox.Show("File created!", "File", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsbtnReload_Click(object sender, EventArgs e)
        {
            lvw1.Items.Clear();
            string[] files = Directory.GetFiles(folder);
            foreach (string fn in files)
                DoParseFile(long.Parse(Path.GetFileNameWithoutExtension(fn)));
        }

        private void tsbtnAoT_Click(object sender, EventArgs e)
        {
            TopMost = tsbtnAoT.Checked;
        }
    }
}
