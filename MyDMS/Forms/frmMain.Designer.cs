

namespace PNB.MyDMS
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileOpenContainingFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuViewAoT = new System.Windows.Forms.ToolStripMenuItem();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmsRestore = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsTree = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmsTreeviewOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
			this.watcher = new System.IO.FileSystemWatcher();
			this.tcDMS = new System.Windows.Forms.TabControl();
			this.tpOrganizations = new System.Windows.Forms.TabPage();
			this.tpCMS = new System.Windows.Forms.TabPage();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.menuStrip1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.cmsTree.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.watcher)).BeginInit();
			this.tcDMS.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.toolsToolStripMenuItem,
            this.mnuView});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1064, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mnuFile
			// 
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpenContainingFolder,
            this.mnuFileSave,
            this.toolStripSeparator2,
            this.mnuFileExit});
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Size = new System.Drawing.Size(37, 20);
			this.mnuFile.Text = "File";
			// 
			// mnuFileOpenContainingFolder
			// 
			this.mnuFileOpenContainingFolder.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileOpenContainingFolder.Image")));
			this.mnuFileOpenContainingFolder.Name = "mnuFileOpenContainingFolder";
			this.mnuFileOpenContainingFolder.Size = new System.Drawing.Size(201, 22);
			this.mnuFileOpenContainingFolder.Text = "Open Containing Folder";
			this.mnuFileOpenContainingFolder.Click += new System.EventHandler(this.mnuFileOpenContainingFolder_Click);
			// 
			// mnuFileSave
			// 
			this.mnuFileSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileSave.Image")));
			this.mnuFileSave.Name = "mnuFileSave";
			this.mnuFileSave.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.mnuFileSave.Size = new System.Drawing.Size(201, 22);
			this.mnuFileSave.Text = "Save";
			this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(198, 6);
			// 
			// mnuFileExit
			// 
			this.mnuFileExit.Name = "mnuFileExit";
			this.mnuFileExit.Size = new System.Drawing.Size(201, 22);
			this.mnuFileExit.Text = "Exit";
			this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsSettings});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			// 
			// mnuToolsSettings
			// 
			this.mnuToolsSettings.Name = "mnuToolsSettings";
			this.mnuToolsSettings.ShortcutKeys = System.Windows.Forms.Keys.F6;
			this.mnuToolsSettings.Size = new System.Drawing.Size(135, 22);
			this.mnuToolsSettings.Text = "Settings";
			this.mnuToolsSettings.Click += new System.EventHandler(this.mnuToolsSettings_Click);
			// 
			// mnuView
			// 
			this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewAoT});
			this.mnuView.Name = "mnuView";
			this.mnuView.Size = new System.Drawing.Size(44, 20);
			this.mnuView.Text = "View";
			// 
			// mnuViewAoT
			// 
			this.mnuViewAoT.CheckOnClick = true;
			this.mnuViewAoT.Name = "mnuViewAoT";
			this.mnuViewAoT.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.mnuViewAoT.Size = new System.Drawing.Size(192, 22);
			this.mnuViewAoT.Text = "Always on Top";
			this.mnuViewAoT.CheckedChanged += new System.EventHandler(this.mnuViewAoT_CheckedChanged);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "My DMS";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRestore});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(114, 26);
			// 
			// cmsRestore
			// 
			this.cmsRestore.Name = "cmsRestore";
			this.cmsRestore.Size = new System.Drawing.Size(113, 22);
			this.cmsRestore.Text = "Restore";
			this.cmsRestore.Click += new System.EventHandler(this.cmsRestore_Click);
			// 
			// cmsTree
			// 
			this.cmsTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsTreeviewOpenFolder});
			this.cmsTree.Name = "cmsTree";
			this.cmsTree.Size = new System.Drawing.Size(140, 26);
			this.cmsTree.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTree_Opening);
			// 
			// cmsTreeviewOpenFolder
			// 
			this.cmsTreeviewOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("cmsTreeviewOpenFolder.Image")));
			this.cmsTreeviewOpenFolder.Name = "cmsTreeviewOpenFolder";
			this.cmsTreeviewOpenFolder.Size = new System.Drawing.Size(139, 22);
			this.cmsTreeviewOpenFolder.Text = "Open Folder";
			this.cmsTreeviewOpenFolder.Click += new System.EventHandler(this.cmsTreeviewOpenFolder_Click);
			// 
			// watcher
			// 
			this.watcher.EnableRaisingEvents = true;
			this.watcher.SynchronizingObject = this;
			// 
			// tcDMS
			// 
			this.tcDMS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tcDMS.Controls.Add(this.tpOrganizations);
			this.tcDMS.Controls.Add(this.tpCMS);
			this.tcDMS.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tcDMS.Location = new System.Drawing.Point(12, 27);
			this.tcDMS.Name = "tcDMS";
			this.tcDMS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tcDMS.RightToLeftLayout = true;
			this.tcDMS.SelectedIndex = 0;
			this.tcDMS.Size = new System.Drawing.Size(1040, 591);
			this.tcDMS.TabIndex = 0;
			// 
			// tpOrganizations
			// 
			this.tpOrganizations.Location = new System.Drawing.Point(4, 25);
			this.tpOrganizations.Name = "tpOrganizations";
			this.tpOrganizations.Padding = new System.Windows.Forms.Padding(3);
			this.tpOrganizations.Size = new System.Drawing.Size(1032, 562);
			this.tpOrganizations.TabIndex = 2;
			this.tpOrganizations.Text = "سازمانها";
			this.tpOrganizations.UseVisualStyleBackColor = true;
			// 
			// tpCMS
			// 
			this.tpCMS.Location = new System.Drawing.Point(4, 25);
			this.tpCMS.Name = "tpCMS";
			this.tpCMS.Padding = new System.Windows.Forms.Padding(3);
			this.tpCMS.Size = new System.Drawing.Size(1032, 562);
			this.tpCMS.TabIndex = 3;
			this.tpCMS.Text = "ارتباط با مشتری";
			this.tpCMS.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 621);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(1064, 22);
			this.statusStrip1.TabIndex = 7;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(108, 17);
			this.toolStripStatusLabel1.Text = "MyDMS - Ver 1.16";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1064, 643);
			this.Controls.Add(this.tcDMS);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MyDMS";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.cmsTree.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.watcher)).EndInit();
			this.tcDMS.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mnuFile;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuToolsSettings;
		private System.Windows.Forms.ToolStripMenuItem mnuFileOpenContainingFolder;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cmsRestore;
		private System.IO.FileSystemWatcher watcher;
		private System.Windows.Forms.ToolStripMenuItem mnuView;
		private System.Windows.Forms.ToolStripMenuItem mnuViewAoT;
		private System.Windows.Forms.ContextMenuStrip cmsTree;
		private System.Windows.Forms.ToolStripMenuItem cmsTreeviewOpenFolder;
		private System.Windows.Forms.TabControl tcDMS;
		private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
		private System.Windows.Forms.TabPage tpOrganizations;
		private System.Windows.Forms.TabPage tpCMS;
	}
}

