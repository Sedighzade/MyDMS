using System;
using System.Windows.Forms;

namespace PNB.GUI.GUIHelper
{
	public partial class frmSingleValue : Form
	{
		public static string GetSingleValueFromUser(Control owner, string frmText, string label, string initialValue, bool autoConfirm = true)
		{
			frmSingleValue f = new frmSingleValue(owner, frmText, label, initialValue, autoConfirm);
			if (f.ShowDialog() != DialogResult.OK) return string.Empty;

			return f.SingleValue.Trim();
		}
		public string SingleValue
		{
			get
			{
				return textBox1.Text;
			}
		}

		bool ac;
		public frmSingleValue(Control owner, string formText, string lableText, string initialValue, bool accept)
		{
			InitializeComponent();

			//this.Owner = owner;
			ac = accept;
			this.Text = formText;
			this.lbl.Text = lableText;
			this.textBox1.Text = initialValue;
			DialogResult = DialogResult.Cancel;
			Load += frmSingleValue_Load;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void frmSingleValue_Load(object sender, EventArgs e)
		{
			if (ac)
				btnOK_Click(null, null);
		}
	}
}
