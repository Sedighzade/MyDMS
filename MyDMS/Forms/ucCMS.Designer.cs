namespace PNB.MyDMS
{
	partial class ucCMS
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCMS));
			this.txtName = new System.Windows.Forms.TextBox();
			this.olv = new BrightIdeasSoftware.TreeListView();
			this.olvColumnName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.olvColumnCreated = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.lstvwCalls = new PNB.GUI.GUIHelper.ListViewEx2();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.baseRenderer1 = new BrightIdeasSoftware.BaseRenderer();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
			this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnExpand = new System.Windows.Forms.ToolStripButton();
			this.tsbtnCollapse = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.olv)).BeginInit();
			this.panel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.txtName.Location = new System.Drawing.Point(4, 38);
			this.txtName.Margin = new System.Windows.Forms.Padding(4);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(1236, 27);
			this.txtName.TabIndex = 0;
			this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp);
			// 
			// olv
			// 
			this.olv.AllColumns.Add(this.olvColumnName);
			this.olv.AllColumns.Add(this.olvColumnCreated);
			this.olv.AllowColumnReorder = true;
			this.olv.AllowDrop = true;
			this.olv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.olv.CellEditUseWholeCell = false;
			this.olv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnName,
            this.olvColumnCreated});
			this.olv.Cursor = System.Windows.Forms.Cursors.Default;
			this.olv.EmptyListMsg = "This folder is completely empty!";
			this.olv.EmptyListMsgFont = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.olv.FullRowSelect = true;
			this.olv.GridLines = true;
			this.olv.HideSelection = false;
			this.olv.IsSimpleDragSource = true;
			this.olv.IsSimpleDropSink = true;
			this.olv.Location = new System.Drawing.Point(743, 104);
			this.olv.Margin = new System.Windows.Forms.Padding(4);
			this.olv.Name = "olv";
			this.olv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.olv.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
			this.olv.ShowCommandMenuOnRightClick = true;
			this.olv.ShowGroups = false;
			this.olv.ShowImagesOnSubItems = true;
			this.olv.ShowItemToolTips = true;
			this.olv.Size = new System.Drawing.Size(497, 565);
			this.olv.TabIndex = 29;
			this.olv.UseCompatibleStateImageBehavior = false;
			this.olv.UseFilterIndicator = true;
			this.olv.UseFiltering = true;
			this.olv.UseHotItem = true;
			this.olv.View = System.Windows.Forms.View.Details;
			this.olv.VirtualMode = true;
			// 
			// olvColumnName
			// 
			this.olvColumnName.AspectName = "Name";
			this.olvColumnName.IsTileViewColumn = true;
			this.olvColumnName.Text = "نام سازمان";
			this.olvColumnName.UseInitialLetterForGroup = true;
			this.olvColumnName.Width = 252;
			this.olvColumnName.WordWrap = true;
			// 
			// olvColumnCreated
			// 
			this.olvColumnCreated.AspectName = "PhoneNumbers";
			this.olvColumnCreated.Text = "شماره‌های تماس";
			this.olvColumnCreated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.olvColumnCreated.Width = 206;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.lstvwCalls);
			this.panel1.Location = new System.Drawing.Point(4, 76);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(731, 593);
			this.panel1.TabIndex = 30;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(18, 347);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(693, 225);
			this.textBox1.TabIndex = 2;
			// 
			// lstvwCalls
			// 
			this.lstvwCalls.AllowColumnReorder = true;
			this.lstvwCalls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstvwCalls.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.lstvwCalls.DoubleClickActivation = false;
			this.lstvwCalls.FitToPage = false;
			this.lstvwCalls.FullRowSelect = true;
			this.lstvwCalls.GridLines = true;
			this.lstvwCalls.HideSelection = false;
			this.lstvwCalls.Location = new System.Drawing.Point(18, 28);
			this.lstvwCalls.Logo = null;
			this.lstvwCalls.Name = "lstvwCalls";
			this.lstvwCalls.PreviewSize = new System.Drawing.Size(500, 500);
			this.lstvwCalls.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lstvwCalls.RightToLeftLayout = true;
			this.lstvwCalls.Size = new System.Drawing.Size(693, 313);
			this.lstvwCalls.TabIndex = 1;
			this.lstvwCalls.Title = "";
			this.lstvwCalls.UseCompatibleStateImageBehavior = false;
			this.lstvwCalls.View = System.Windows.Forms.View.Details;
			this.lstvwCalls.SelectedIndexChanged += new System.EventHandler(this.lstvwCalls_SelectedIndexChanged);
			this.lstvwCalls.DoubleClick += new System.EventHandler(this.lstvwCalls_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "تاریخ ایجاد";
			this.columnHeader1.Width = 150;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "موضوع";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Width = 300;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "شخص";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader3.Width = 200;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnCollapse,
            this.tsbtnExpand,
            this.toolStripSeparator1,
            this.tsbtnAdd,
            this.tsbtnEdit});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.toolStrip1.Size = new System.Drawing.Size(1262, 25);
			this.toolStrip1.TabIndex = 31;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbtnAdd
			// 
			this.tsbtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnAdd.Enabled = false;
			this.tsbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAdd.Image")));
			this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAdd.Name = "tsbtnAdd";
			this.tsbtnAdd.Size = new System.Drawing.Size(23, 22);
			this.tsbtnAdd.Text = "Add New Call";
			// 
			// tsbtnEdit
			// 
			this.tsbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnEdit.Enabled = false;
			this.tsbtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEdit.Image")));
			this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnEdit.Name = "tsbtnEdit";
			this.tsbtnEdit.Size = new System.Drawing.Size(23, 22);
			this.tsbtnEdit.Text = "Edit";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbtnExpand
			// 
			this.tsbtnExpand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnExpand.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnExpand.Image")));
			this.tsbtnExpand.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnExpand.Name = "tsbtnExpand";
			this.tsbtnExpand.Size = new System.Drawing.Size(23, 22);
			this.tsbtnExpand.Text = "Expand";
			this.tsbtnExpand.Click += new System.EventHandler(this.tsbtnExpand_Click);
			// 
			// tsbtnCollapse
			// 
			this.tsbtnCollapse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnCollapse.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCollapse.Image")));
			this.tsbtnCollapse.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnCollapse.Name = "tsbtnCollapse";
			this.tsbtnCollapse.Size = new System.Drawing.Size(23, 22);
			this.tsbtnCollapse.Text = "Collapse";
			this.tsbtnCollapse.Click += new System.EventHandler(this.tsbtnCollapse_Click);
			// 
			// ucCMS
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.olv);
			this.Controls.Add(this.txtName);
			this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ucCMS";
			this.Size = new System.Drawing.Size(1262, 687);
			//this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ucCMS_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.olv)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtName;
		private BrightIdeasSoftware.TreeListView olv;
		private BrightIdeasSoftware.OLVColumn olvColumnName;
		private BrightIdeasSoftware.OLVColumn olvColumnCreated;
		private System.Windows.Forms.Panel panel1;
		private GUI.GUIHelper.ListViewEx2 lstvwCalls;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private BrightIdeasSoftware.BaseRenderer baseRenderer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbtnAdd;
		private System.Windows.Forms.ToolStripButton tsbtnEdit;
		private System.Windows.Forms.ToolStripButton tsbtnExpand;
		private System.Windows.Forms.ToolStripButton tsbtnCollapse;
	}
}
