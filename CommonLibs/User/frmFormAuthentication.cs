using System;
using System.Drawing;
using System.Windows.Forms;

namespace PNB.Lib.UserMgmt
{
    public partial class frmFormAuthentication : Form
    {
        public bool End { set; get; }
        SM sm1 = null;
        User[] users1;
        User user;
        public User AuthenticatedUser { get { return user; } }

        public frmFormAuthentication(SM sm, User[] pUsers)
        {
            sm1 = sm;
            users1 = pUsers;
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
            btnLogin.Location = new Point((Width - btnLogin.Width) / 2, btnLogin.Top);
            //pbLock.Location = new Point(pbLock.Left, (Height - pbLock.Height) / 2);

#if DEBUG
            txtUN.Text = "a.dehghan";
            txtPass.Text = "6529";
#endif
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUN.Text.Trim()))
            {
                MessageBox.Show(this, "Enter username!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUN.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPass.Text.Trim()))
            {
                MessageBox.Show(this, "Enter password!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPass.Focus();
                return;
            }

            foreach (User u in users1)
                if (u.UserName == txtUN.Text.Trim() && u.Password == txtPass.Text.Trim())
                {
                    user = u;
                    break;
                }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void txtUN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                txtPass.Focus();
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogin.Focus();
        }

        private void txtPass_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = txtPass.PointToScreen(e.Location);
            Text = p.ToString() + "--" + e.Location.ToString();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

        private void pbShutdown_Click(object sender, EventArgs e)
        {
            End = true;
            Close();
        }

       
    }
}
