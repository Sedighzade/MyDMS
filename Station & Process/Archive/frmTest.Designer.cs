namespace PNB.SAS.Archive
{
    partial class frmTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.lvw1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtSrt = new System.Windows.Forms.DateTimePicker();
            this.lvw2 = new GUI.ListViewEx.ListViewEx2();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnOpenFolder = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDeleteFiles = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFill = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCreateFile = new System.Windows.Forms.ToolStripButton();
            this.tstxtIED = new System.Windows.Forms.ToolStripTextBox();
            this.tsbtnReload = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAoT = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvw1
            // 
            this.lvw1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader11});
            this.lvw1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvw1.FullRowSelect = true;
            this.lvw1.GridLines = true;
            this.lvw1.Location = new System.Drawing.Point(0, 0);
            this.lvw1.Name = "lvw1";
            this.lvw1.Size = new System.Drawing.Size(776, 111);
            this.lvw1.TabIndex = 5;
            this.lvw1.UseCompatibleStateImageBehavior = false;
            this.lvw1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File Version";
            this.columnHeader2.Width = 66;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "IED";
            this.columnHeader3.Width = 136;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Time of Creation";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Last Save Time";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "#Slot";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvw1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dtEnd);
            this.splitContainer1.Panel2.Controls.Add(this.dtSrt);
            this.splitContainer1.Panel2.Controls.Add(this.lvw2);
            this.splitContainer1.Size = new System.Drawing.Size(776, 356);
            this.splitContainer1.SplitterDistance = 111;
            this.splitContainer1.TabIndex = 6;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(279, 19);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 20);
            this.dtEnd.TabIndex = 2;
            // 
            // dtSrt
            // 
            this.dtSrt.Location = new System.Drawing.Point(19, 19);
            this.dtSrt.Name = "dtSrt";
            this.dtSrt.Size = new System.Drawing.Size(200, 20);
            this.dtSrt.TabIndex = 1;
            // 
            // lvw2
            // 
            this.lvw2.AllowColumnReorder = true;
            this.lvw2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvw2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader12});
            this.lvw2.FullRowSelect = true;
            this.lvw2.GridLines = true;
            this.lvw2.Location = new System.Drawing.Point(0, 45);
            this.lvw2.Name = "lvw2";
            this.lvw2.Size = new System.Drawing.Size(773, 193);
            this.lvw2.TabIndex = 0;
            this.lvw2.UseCompatibleStateImageBehavior = false;
            this.lvw2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "";
            this.columnHeader6.Width = 25;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Time";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Size";
            this.columnHeader12.Width = 100;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnOpenFolder,
            this.tsbtnDeleteFiles,
            this.tsbtnFill,
            this.tsbtnCreateFile,
            this.tstxtIED,
            this.tsbtnReload,
            this.tsbtnAoT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnOpenFolder
            // 
            this.tsbtnOpenFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnOpenFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOpenFolder.Image")));
            this.tsbtnOpenFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOpenFolder.Name = "tsbtnOpenFolder";
            this.tsbtnOpenFolder.Size = new System.Drawing.Size(23, 22);
            this.tsbtnOpenFolder.Text = "Open Folder";
            this.tsbtnOpenFolder.Click += new System.EventHandler(this.tsbtnOpenFolder_Click);
            // 
            // tsbtnDeleteFiles
            // 
            this.tsbtnDeleteFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDeleteFiles.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDeleteFiles.Image")));
            this.tsbtnDeleteFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDeleteFiles.Name = "tsbtnDeleteFiles";
            this.tsbtnDeleteFiles.Size = new System.Drawing.Size(23, 22);
            this.tsbtnDeleteFiles.Text = "Delete Files";
            this.tsbtnDeleteFiles.Click += new System.EventHandler(this.tsbtnDeleteFiles_Click);
            // 
            // tsbtnFill
            // 
            this.tsbtnFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFill.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFill.Image")));
            this.tsbtnFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFill.Name = "tsbtnFill";
            this.tsbtnFill.Size = new System.Drawing.Size(23, 22);
            this.tsbtnFill.Text = "Fill Files";
            this.tsbtnFill.Click += new System.EventHandler(this.tsbtnFill_Click);
            // 
            // tsbtnCreateFile
            // 
            this.tsbtnCreateFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnCreateFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCreateFile.Image")));
            this.tsbtnCreateFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCreateFile.Name = "tsbtnCreateFile";
            this.tsbtnCreateFile.Size = new System.Drawing.Size(23, 22);
            this.tsbtnCreateFile.Text = "Create File";
            this.tsbtnCreateFile.Click += new System.EventHandler(this.tsbtnCreateFile_Click);
            // 
            // tstxtIED
            // 
            this.tstxtIED.Name = "tstxtIED";
            this.tstxtIED.Size = new System.Drawing.Size(100, 25);
            this.tstxtIED.Text = "1001";
            // 
            // tsbtnReload
            // 
            this.tsbtnReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnReload.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnReload.Image")));
            this.tsbtnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnReload.Name = "tsbtnReload";
            this.tsbtnReload.Size = new System.Drawing.Size(23, 22);
            this.tsbtnReload.Text = "Reload";
            this.tsbtnReload.Click += new System.EventHandler(this.tsbtnReload_Click);
            // 
            // tsbtnAoT
            // 
            this.tsbtnAoT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAoT.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAoT.Image")));
            this.tsbtnAoT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAoT.Name = "tsbtnAoT";
            this.tsbtnAoT.Size = new System.Drawing.Size(23, 22);
            this.tsbtnAoT.Text = "Always on Top";
            this.tsbtnAoT.Click += new System.EventHandler(this.tsbtnAoT_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 396);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvw1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private GUI.ListViewEx.ListViewEx2 lvw2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtSrt;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnOpenFolder;
        private System.Windows.Forms.ToolStripButton tsbtnDeleteFiles;
        private System.Windows.Forms.ToolStripButton tsbtnFill;
        private System.Windows.Forms.ToolStripButton tsbtnCreateFile;
        private System.Windows.Forms.ToolStripTextBox tstxtIED;
        private System.Windows.Forms.ToolStripButton tsbtnReload;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ToolStripButton tsbtnAoT;
    }
}