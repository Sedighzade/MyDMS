using System;
using System.Drawing;
using System.Windows.Forms;

namespace PNB.GUI.GUIHelper
{
    public partial class frmTimedDialog : Form
    {
        public frmTimedDialog(string message)
        {
            InitializeComponent();
            label1.Text = message;
            label1.Location = new Point((Width - label1.Width) / 2, (Height - label1.Height) / 2);
        }
        public int TimerInterval { set { timer1.Interval = value; } get { return timer1.Interval; } }

        private void frmTimedDialog_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Close();
        }

        public static void ShowMessage(string msg, int interval)
        {
            frmTimedDialog f = new frmTimedDialog(msg);
            f.TimerInterval = interval;
            f.ShowDialog();
        }
    }
}
