
namespace PNB.MyDMS
{
	partial class ucOrganization
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOrganization));
			this.label1 = new System.Windows.Forms.Label();
			this.txtOrgName = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.prptOffice = new System.Windows.Forms.PropertyGrid();
			this.lstbxEntity = new System.Windows.Forms.ListBox();
			this.lstbxOrg = new PNB.GUI.GUIHelper.ListViewEx2();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbtnSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAddOrganization = new System.Windows.Forms.ToolStripButton();
			this.tsbtnDeleteOrganization = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tslblOrgCount = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbtnAddEntity = new System.Windows.Forms.ToolStripButton();
			this.tsbtnDeleteEntity = new System.Windows.Forms.ToolStripButton();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.panel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.label1.Location = new System.Drawing.Point(900, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 19);
			this.label1.TabIndex = 11;
			this.label1.Text = "نام سازمان";
			// 
			// txtOrgName
			// 
			this.txtOrgName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOrgName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
			this.txtOrgName.Location = new System.Drawing.Point(3, 10);
			this.txtOrgName.Name = "txtOrgName";
			this.txtOrgName.Size = new System.Drawing.Size(891, 27);
			this.txtOrgName.TabIndex = 7;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.prptOffice);
			this.panel1.Controls.Add(this.lstbxEntity);
			this.panel1.Controls.Add(this.lstbxOrg);
			this.panel1.Controls.Add(this.toolStrip1);
			this.panel1.Location = new System.Drawing.Point(3, 43);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(976, 372);
			this.panel1.TabIndex = 13;
			// 
			// prptOffice
			// 
			this.prptOffice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.prptOffice.HelpVisible = false;
			this.prptOffice.Location = new System.Drawing.Point(12, 25);
			this.prptOffice.Name = "prptOffice";
			this.prptOffice.Size = new System.Drawing.Size(357, 342);
			this.prptOffice.TabIndex = 3;
			this.prptOffice.ToolbarVisible = false;
			// 
			// lstbxEntity
			// 
			this.lstbxEntity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstbxEntity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstbxEntity.FormattingEnabled = true;
			this.lstbxEntity.ItemHeight = 16;
			this.lstbxEntity.Location = new System.Drawing.Point(375, 25);
			this.lstbxEntity.Name = "lstbxEntity";
			this.lstbxEntity.Size = new System.Drawing.Size(299, 340);
			this.lstbxEntity.TabIndex = 2;
			// 
			// lstbxOrg
			// 
			this.lstbxOrg.AllowColumnReorder = true;
			this.lstbxOrg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstbxOrg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.lstbxOrg.DoubleClickActivation = false;
			this.lstbxOrg.FitToPage = false;
			this.lstbxOrg.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lstbxOrg.FullRowSelect = true;
			this.lstbxOrg.GridLines = true;
			this.lstbxOrg.HideSelection = false;
			this.lstbxOrg.Location = new System.Drawing.Point(677, 25);
			this.lstbxOrg.Logo = null;
			this.lstbxOrg.Name = "lstbxOrg";
			this.lstbxOrg.PreviewSize = new System.Drawing.Size(500, 500);
			this.lstbxOrg.RightToLeftLayout = true;
			this.lstbxOrg.Size = new System.Drawing.Size(296, 342);
			this.lstbxOrg.TabIndex = 1;
			this.lstbxOrg.Title = "";
			this.lstbxOrg.UseCompatibleStateImageBehavior = false;
			this.lstbxOrg.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "سازمان";
			this.columnHeader1.Width = 244;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsbtnSave,
            this.toolStripSeparator1,
            this.tsbtnAddOrganization,
            this.tsbtnDeleteOrganization,
            this.toolStripSeparator3,
            this.tslblOrgCount,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.tsbtnAddEntity,
            this.tsbtnDeleteEntity});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(976, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbtnSave
			// 
			this.tsbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSave.Image")));
			this.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnSave.Name = "tsbtnSave";
			this.tsbtnSave.Size = new System.Drawing.Size(23, 22);
			this.tsbtnSave.Text = "ذخیره";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbtnAddOrganization
			// 
			this.tsbtnAddOrganization.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnAddOrganization.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddOrganization.Image")));
			this.tsbtnAddOrganization.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAddOrganization.Name = "tsbtnAddOrganization";
			this.tsbtnAddOrganization.Size = new System.Drawing.Size(23, 22);
			this.tsbtnAddOrganization.Text = "افزودن سازمان";
			// 
			// tsbtnDeleteOrganization
			// 
			this.tsbtnDeleteOrganization.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnDeleteOrganization.Enabled = false;
			this.tsbtnDeleteOrganization.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDeleteOrganization.Image")));
			this.tsbtnDeleteOrganization.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDeleteOrganization.Name = "tsbtnDeleteOrganization";
			this.tsbtnDeleteOrganization.Size = new System.Drawing.Size(23, 22);
			this.tsbtnDeleteOrganization.Text = "حذف سازمان";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// tslblOrgCount
			// 
			this.tslblOrgCount.Name = "tslblOrgCount";
			this.tslblOrgCount.Size = new System.Drawing.Size(64, 22);
			this.tslblOrgCount.Text = "Count: 000";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbtnAddEntity
			// 
			this.tsbtnAddEntity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnAddEntity.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAddEntity.Image")));
			this.tsbtnAddEntity.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnAddEntity.Name = "tsbtnAddEntity";
			this.tsbtnAddEntity.Size = new System.Drawing.Size(23, 22);
			this.tsbtnAddEntity.Text = "افزودن اداره/شخص";
			// 
			// tsbtnDeleteEntity
			// 
			this.tsbtnDeleteEntity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbtnDeleteEntity.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDeleteEntity.Image")));
			this.tsbtnDeleteEntity.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbtnDeleteEntity.Name = "tsbtnDeleteEntity";
			this.tsbtnDeleteEntity.Size = new System.Drawing.Size(23, 22);
			this.tsbtnDeleteEntity.Text = "Delete Entity";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.BackColor = System.Drawing.Color.PeachPuff;
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(47, 22);
			this.toolStripLabel1.Text = "سازمانها";
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(46, 22);
			this.toolStripLabel2.Text = "اشخاص";
			// 
			// ucOrganization
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtOrgName);
			this.Name = "ucOrganization";
			this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.Size = new System.Drawing.Size(986, 469);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtOrgName;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private GUI.GUIHelper.ListViewEx2 lstbxOrg;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ToolStripButton tsbtnDeleteOrganization;
		private System.Windows.Forms.ToolStripButton tsbtnSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel tslblOrgCount;
		private System.Windows.Forms.ToolStripButton tsbtnAddOrganization;
		private System.Windows.Forms.ListBox lstbxEntity;
		private System.Windows.Forms.PropertyGrid prptOffice;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbtnAddEntity;
		private System.Windows.Forms.ToolStripButton tsbtnDeleteEntity;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
	}
}
