using MyDMS.Secretariat;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace MyDMS.Forms.SecretaraitForms
{
    public partial class frmNewLetter : Form
    {
        Letter lett = null;
        Secretarait sec;
        public Letter NewLetter { get { return lett; } }

        public frmNewLetter(Secretarait secretariat)
        {
            sec = secretariat;
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
            //txtCreationDate.Text = DateTime.Now.ToString("  yyyy-MM-dd        HH:mm");
            cmbxOrgs.Items.AddRange(sec.Organizations.ToArray());
            if (cmbxOrgs.Items.Count > 0)
                cmbxOrgs.SelectedIndex = 0;
            txtSerial.Text = sec.SerialLetter.GetLetterSerialCode(Serial.SerialMethod.M1, DateTime.Now);


            lblBrwoseAttachedFile.Click += delegate
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog(this) == DialogResult.Cancel) return;

                txtAttachedFile.Text = ofd.FileName;
            };
        }

        public frmNewLetter(Secretarait secretariat, Letter letter) : this(secretariat)
        {
            Text = "ویرایش نامه";
            this.btnAdd.Text = "ویرایش";
            lett = letter;
            IEnumerable<Organization> q = cmbxOrgs.Items.Cast<Organization>().Where(x => x.ID == lett.Organization);
            if (q.Count<Organization>() > 0)
                cmbxOrgs.SelectedItem = q.ElementAt<Organization>(0);
            txtSerial.Text = lett.Serial;
            txtSubject.Text = lett.Subject;
            txtLetterText.Text = lett.Text;
            dtCreation.Value = new DateTime(lett.CreationDate);
            dtSend.Value = new DateTime(lett.SendDate);
            txtCode.Text = lett.Code;
            txtAttachedFile.Text = lett.AttachedFile;
        }

        private void FillOrgs(List<Organization> orgs)
        {
            cmbxOrgs.Items.Clear();
            cmbxOrgs.Items.AddRange(orgs.ToArray());
            if (cmbxOrgs.Items.Count > 0)
                cmbxOrgs.SelectedIndex = 0;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (DoAdd())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private bool DoAdd()
        {
            bool res = false;
            res = /*string.IsNullOrWhiteSpace(txtCode.Text) ||*/ string.IsNullOrWhiteSpace(txtSubject.Text) ||
                string.IsNullOrWhiteSpace(txtLetterText.Text) || cmbxOrgs.Items.Count == 0;

            if (res)
            {
                MessageBox.Show(this, "Fill all necessary fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            /// docs by behzad @ 98.02.118
            /// if lett ==null then we are adding a new item, else we are editing an item.
            if (lett == null)
                lett = new Letter();

            lett.Serial = txtSerial.Text;
            lett.Organization = (cmbxOrgs.SelectedItem as Organization).ID;
            lett.Subject = txtSubject.Text.Trim();
            lett.CreationDate = dtCreation.Value.Ticks;
            lett.SendDate = dtSend.Value.Ticks;
            lett.Text = txtLetterText.Text.Trim();
            lett.Code = txtCode.Text;
            lett.AttachedFile = txtAttachedFile.Text;

            return true;
        }

        private void btnAddNewReceipient_Click(object sender, EventArgs e)
        {
            //frmOrganization f = new frmOrganization(sec);
            //if (f.ShowDialog(this) == DialogResult.Cancel) return;
            //FillOrgs(sec.Organizations);
            //cmbxOrgs.SelectedItem = f.NewlyAdded;
        }

        private void chkbxEditCreatonDate_CheckedChanged(object sender, EventArgs e)
        {
            dtCreation.Enabled = chkbxEditCreatonDate.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lett == null) return;
            if (string.IsNullOrEmpty(lett.AttachedFile))
            {
                MessageBox.Show(this, "No file!", "Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(lett.AttachedFile))
            {
                MessageBox.Show(this, "File not found!", "Open File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Process.Start(lett.AttachedFile);
        }
    }
}
