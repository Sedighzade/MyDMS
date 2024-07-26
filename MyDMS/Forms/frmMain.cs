using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PNB.MyDMS
{
	public partial class frmMain : Form
	{
		ucCMS uccms;
		ucOrganization ucorg;
		App app;
		public frmMain(App app1)
		{
			app = app1;
			InitializeComponent();

			ucorg = new ucOrganization(app.AppSettings.SecretariatData);
			ucorg.DataChanged += Ucorg_DataChanged;
			ucorg.Dock = DockStyle.Fill;

			uccms = new ucCMS(app.AppSettings.SecretariatData);
			uccms.Dock = DockStyle.Fill;
			tpOrganizations.Controls.Add(ucorg);
			tpCMS.Controls.Add(uccms);
			tcDMS.SelectedIndexChanged += delegate
			{
				switch (tcDMS.SelectedIndex)
				{
					case 0:
						tpOrganizations.Controls[0].Focus();
						break;
					case 1:
						tpCMS.Controls[0].Focus();
						break;
				}
			};
			watcher.Changed += new FileSystemEventHandler(OnChanged);
			watcher.Created += new FileSystemEventHandler(OnChanged);
			watcher.Deleted += new FileSystemEventHandler(OnChanged);
			watcher.Renamed += new RenamedEventHandler(OnRenamed);

			this.Size = new Size(Size.Width + 100, Size.Height);
			this.WindowState = app.AppSettings.MaximizeMainWindow ? FormWindowState.Maximized : FormWindowState.Normal;

			tcDMS.SelectedIndex = 1;
			tcDMS.SelectedIndex = 0;

			ThreadPool.QueueUserWorkItem(new WaitCallback(CheckFiles));
		}

		private void Ucorg_DataChanged(object sender, EventArgs e)
		{
			uccms.RefreashTreeView();
		}

		void CheckFiles(object arg)
		{
			//Microsoft.Office.Interop.Word._Application word = new();
			//object miss = System.Reflection.Missing.Value;
			//object path = @"C:\DOC\myDocument.docx";
			//object readOnly = true;
			//Microsoft.Office.Interop.Word.Document docs = word.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
			//string totaltext = "";
			//for (int i = 0; i < docs.Paragraphs.Count; i++)
			//{
			//    totaltext += " \r\n " + docs.Paragraphs[i + 1].Range.Text.ToString();
			//}
			//Console.WriteLine(totaltext);
			//docs.Close();
			//word.Quit();
		}

		private void OnRenamed(object sender, RenamedEventArgs e)
		{
			//richTextBox1.Text += "\nFile: " + e.FullPath + " " + e.ChangeType;
		}
		private void OnChanged(object sender, FileSystemEventArgs e)
		{
			//richTextBox1.Text += string.Format("\nFile: {0} renamed to {1}", e.Name, e.FullPath);
		}

		#region Forms 
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			notifyIcon1.Visible = false;

		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			DoAfterLoad();
		}

		private void frmMain_Resize(object sender, EventArgs e)
		{
			notifyIcon1.Visible = WindowState == FormWindowState.Minimized;
			ShowInTaskbar = WindowState != FormWindowState.Minimized;
		}
		#endregion

		#region Menu Items
		private void mnuFileOpenContainingFolder_Click(object sender, EventArgs e)
		{
			Process.Start("explorer.exe", app.AppSettings.TemporaryData.AppPath);
		}
		private void mnuFileSave_Click(object sender, EventArgs e)
		{
			app.Save(app.AppSettings);
			MessageBox.Show(this, "Letters saved.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		private void mnuFileExit_Click(object sender, EventArgs e)
		{
			Close();
		}
		private void mnuToolsSettings_Click(object sender, EventArgs e)
		{
			frmSettings f = new MyDMS.frmSettings(app.AppSettings);

			f.ShowDialog(this);


			//app.Save(app.AppSettings);
		}
		private void mnuViewAoT_CheckedChanged(object sender, EventArgs e)
		{
			TopMost = mnuViewAoT.Checked;
		}
		#endregion

		#region Other
		private void cmsRestore_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Normal;
		}
		private void DoAfterLoad()
		{
			//watch first folder
			if (app.AppSettings.Paths.Count > 0)
				if (Directory.Exists(app.AppSettings.Paths[0]))
				{
					watcher.Path = app.AppSettings.Paths[0];
					watcher.NotifyFilter = NotifyFilters.LastAccess
						| NotifyFilters.LastWrite
						| NotifyFilters.FileName
						| NotifyFilters.DirectoryName;
					//watcher.Filter = "*.txt";
					watcher.EnableRaisingEvents = true;
				}
		}
		private void cmsTree_Opening(object sender, CancelEventArgs e)
		{
			//Point p = tvPaths.PointToClient(Form.MousePosition);
			//e.Cancel = tvPaths.GetNodeAt(p) == null;
		}
		private void cmsTreeviewOpenFolder_Click(object sender, EventArgs e)
		{
			//TreeNode tn = tvPaths.SelectedNode;
			//if (tn.Text == "All") return;
			//Process.Start("explorer", tn.Text);
		}


		#endregion

	}
}
