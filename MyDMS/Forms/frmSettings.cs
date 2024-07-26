using MyDMS.DMS;
using System;
using System.Windows.Forms;

namespace PNB.MyDMS
{
    public partial class frmSettings : Form
    {
        Settings sett;
        public frmSettings(Settings s)
        {
            sett = s;
            InitializeComponent();
            listBox1.Items.AddRange(sett.Paths.ToArray());
            propertyGrid1.SelectedObject = s.SecretariatData;
            propertyGrid2.SelectedObject = s;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.Cancel) return;
            listBox1.Items.Add(fbd.SelectedPath);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == ListBox.NoMatches) return;

            listBox1.Items.Remove(listBox1.SelectedItem.ToString());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            sett.Paths.Clear();
            foreach (object o in listBox1.Items)
                sett.Paths.Add(o.ToString());

            Close();
        }
    }
}
