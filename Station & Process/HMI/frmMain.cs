using PNB.Helpers;
using PNB.SAS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNB.SAS.HMI
{
    public partial class frmMain : Form
    {
        SystemApp sa;
        bool askToExit;
        public frmMain(SystemApp systemApp)
        {
            sa = systemApp;
            InitializeComponent();

            askToExit = true;
            SizeChanged += delegate
            {
                //FormBorderStyle = WindowState == FormWindowState.Maximized ? FormBorderStyle.None : FormBorderStyle.Sizable;
            };
            FormClosing += delegate (Object sender, FormClosingEventArgs e)
            {
                if (askToExit) { }
            };

            tvMain.MouseClick += tvMain_MouseClick;
            tvMain.BeforeSelect += tvMain_BeforeSelect;
            tvMain.AfterSelect += tvMain_AfterSelect;

            WindowState = FormWindowState.Maximized;
            tvMain.Nodes.Add("Root");
        }
        public void DoFillView()
        {
            this.Invoke((MethodInvoker)delegate
            {
                DoInternalFillView();
            });

        }
        private void DoInternalFillView()
        {

        }

        private void tvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }
        private void tvMain_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
        }
        private void tvMain_MouseClick(object sender, MouseEventArgs e)
        {
            Point pt = e.Location;
            TreeNode tn = tvMain.GetNodeAt(pt);
            if (tn == null) return;
            DoTreeview(tn);
        }
        private void DoTreeview(TreeNode tn) { }

        private void tmr_Tick(object sender, EventArgs e)
        {
            DoPeriodicTasks();
        }
        private void DoPeriodicTasks()
        {
            DateTime dt = DateTime.Now;
            tsstatusDateTime.Text = Util.ConvertTimeToString(dt, false);
        }

        private void tsbtnWSNormal_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            askToExit = false;
            Close();
        }

        private void DoExit()
        {
        }
    }
}
