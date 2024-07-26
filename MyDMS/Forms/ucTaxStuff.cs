using PNB.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNB.MyDMS.Forms
{
    public partial class ucTaxStuff : UserControl
    {
        char[] ch1 = new char[] { ' ' };
        char[] ch2 = new char[] { ',' };
        string[] lines = null;
        string file = "Services.CSV";
        public ucTaxStuff()
        {
            InitializeComponent();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DoSearch();
        }
        private void DoSearch()
        {
            lblTotalSearchCount.Text = "Total: 0";
            cmbxFiles.Enabled = btnSearch.Enabled = txtSearchBox.Enabled = false;

            string[] chks = txtSearchBox.Text.Split(ch1);
            ThreadPool.QueueUserWorkItem(delegate { DoSearch(chks, true); });
        }
        private void DoSearch(string[] words, bool all)
        {
            if (words == null) return;
            if (words.Length == 0) return;


            List<ListViewItem> items = new List<ListViewItem>();
            foreach (string line in lines)
            {
                bool res = true;
                foreach (string word in words)
                {
                    int temp = line.IndexOf(word, StringComparison.InvariantCultureIgnoreCase);
                    //if (temp >= 0) { }
                    res &= temp != -1;
                }
                if (res)
                    items.Add(GetListViewItem(line));
            }

            Invoke((MethodInvoker)delegate
            {
                listViewEx21.Items.Clear();

                listViewEx21.BeginUpdate();
                listViewEx21.Items.AddRange(items.ToArray());
                listViewEx21.EndUpdate();
                lblTotalSearchCount.Text = "Total: " + items.Count;
                MessageBox.Show("Finished!\n" + lblTotalSearchCount.Text);
                cmbxFiles.Enabled = btnSearch.Enabled = txtSearchBox.Enabled = true;
            });
        }

        ListViewItem GetListViewItem(string text)
        {
            string[] chks = text.Split(ch2);
            ListViewItem item = new ListViewItem(chks[0]);
            item.SubItems.Add(text);
            return item;
        }
        private void ucTaxStuff_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Environment.CurrentDirectory, "*.csv");
            cmbxFiles.Items.AddRange(files);
            if (files.Length > 0)
                cmbxFiles.SelectedIndex = 0;
        }

        private void txtSearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DoSearch();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(listViewEx21.SelectedItems[0].SubItems[0].Text);
        }

        private void listViewEx21_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCopy.Enabled = listViewEx21.SelectedItems.Count > 0;
        }

        private void cmbxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string file = cmbxFiles.SelectedItem.ToString();
            lines = File.ReadAllLines(file);
        }
    }
}
