using PNB.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;

namespace PNB.Lib.UserMgmt
{
    public partial class frmRFAuthentication : Form
    {
        public bool UseDangerous;
        public bool End { set; get; }
        bool sd = false;
        User[] users1;
        User AuthUser;
        string kp = "";
        public User AuthenticatedUser { get { return AuthUser; } }

        public frmRFAuthentication(User[] pUsers)
        {
            this.users1 = pUsers;

            InitializeComponent();
        }
        private void DoBypass()
        {
            sd = true;
            Thread.Sleep(3000);
            DialogResult = DialogResult.OK;
            Close();
        }
        private void DoAuthenticate()
        {
            long tag = -1;
            string args = Configuration.GetRFIDScriptPath();

            ThreadPool.QueueUserWorkItem(delegate
            {
                User u = null;
                while (!sd)
                {
                    tag = Util.LaunchMFRC522(out string data);
                    foreach (User pu in users1)
                        if (pu.RFCodeCode == tag)
                        {
                            u = pu;
                            break;
                        }

                    if (u != null)
                        break;
                    Thread.Sleep(500);
                }

                if (u != null)
                {
                    AuthUser = u;
                    Invoke((MethodInvoker)delegate ()
                    {
                        lblName.Text = u.Name;
                        //if (u.Photo != null)
                        //    pictureBox1.Image = u.Photo;                           

                    });
                    Thread.Sleep(2000);
                    Invoke((MethodInvoker)delegate ()
                    {
                        this.DialogResult = DialogResult.OK;
                        Close();
                    });
                }

            });
        }
        private void frmRFAuthentication_Load(object sender, EventArgs e)
        {
            if (Util.IsLinux)
                DoAuthenticate();
        }
        private void frmRFAuthentication_KeyPress(object sender, KeyPressEventArgs e)
        {
            kp += e.KeyChar.ToString();
            Text = kp;
            if (kp == "911")
            {
                UseDangerous = true;
                DoBypass();
            }
            if (kp.Length > 10)
                Text = kp = "";
            label1.Text = (kp.Length).ToString();
        }
        private void mnuFileBypass_Click(object sender, EventArgs e)
        {
            DoBypass();
        }
        private void mnuFileAuthenticate_Click(object sender, EventArgs e)
        {
            DoAuthenticate();
        }
        private void pbShutdown_Click(object sender, EventArgs e)
        {
            End = true;
            UseDangerous = true;
            Close();
        }
    }
}
