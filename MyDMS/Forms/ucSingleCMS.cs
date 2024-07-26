using MyDMS.Secretariat;
using System;
using System.Windows.Forms;
using PNB.Helpers;
namespace PNB.MyDMS
{
	public partial class ucSingleCMS : Form
	{
		OEntity oe;
		Organization org;
		Call call;
		public Call CallData { get { return call; } }
		public ucSingleCMS(Organization organization, OEntity oentity)
		{
			org = organization;
			oe = oentity;
			InitializeComponent();
			DialogResult = DialogResult.Cancel;
			lblDateTime.Text = PersianCalendar.GregorianToJalali(DateTime.Now.Ticks, true);
			txtEntity.Text = oe.Name;
			txtOrg.Text = org.Name;
		}
		public ucSingleCMS(Organization organization, OEntity oentity, Call preCall)
		{
			org = organization;
			oe = oentity;
			InitializeComponent();
			DialogResult = DialogResult.Cancel;
			lblDateTime.Text = PersianCalendar.GregorianToJalali(DateTime.Now.Ticks, true);
			txtEntity.Text = oe.Name;
			txtOrg.Text = org.Name;
			if (preCall != null)
			{
				call = preCall;
				txtDesc.Text = call.Description;
				txtSubject.Text = call.Subject;
				txtDesc.Enabled = txtSubject.Enabled = btnOK.Enabled = false;
				txtFileAttachment.Text = call.AttachedFilePath;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DoOK();
		}

		private void DoOK()
		{
			#region Validation
			if (string.IsNullOrEmpty(txtSubject.Text))
			{
				txtSubject.Focus();
				MessageBox.Show(this, "Enter a value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			#endregion

			call = new Call();
			call.OE = oe.ID;
			call.Subject = txtSubject.Text;
			call.Description = txtDesc.Text;
			call.AttachedFilePath = txtFileAttachment.Text;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void tsbtnAttachment_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();

			openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
			openFileDialog1.Filter = "All files (*.*)|*.*";
			openFileDialog1.RestoreDirectory = true;
			if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
				return;

			txtFileAttachment.Text = openFileDialog1.FileName;

		}
	}
}
