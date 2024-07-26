namespace PNB.MyDMS.Forms
{
    partial class ucTaxStuff
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
            this.listViewEx21 = new PNB.GUI.GUIHelper.ListViewEx2();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.lblTotalSearchCount = new System.Windows.Forms.Label();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCopy = new System.Windows.Forms.Button();
            this.cmbxFiles = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listViewEx21
            // 
            this.listViewEx21.AllowColumnReorder = true;
            this.listViewEx21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewEx21.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1});
            this.listViewEx21.DoubleClickActivation = false;
            this.listViewEx21.FitToPage = false;
            this.listViewEx21.FullRowSelect = true;
            this.listViewEx21.GridLines = true;
            this.listViewEx21.HideSelection = false;
            this.listViewEx21.Location = new System.Drawing.Point(16, 99);
            this.listViewEx21.Logo = null;
            this.listViewEx21.Name = "listViewEx21";
            this.listViewEx21.PreviewSize = new System.Drawing.Size(500, 500);
            this.listViewEx21.Size = new System.Drawing.Size(650, 478);
            this.listViewEx21.TabIndex = 0;
            this.listViewEx21.Title = "";
            this.listViewEx21.UseCompatibleStateImageBehavior = false;
            this.listViewEx21.View = System.Windows.Forms.View.Details;
            this.listViewEx21.SelectedIndexChanged += new System.EventHandler(this.listViewEx21_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 901;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(70, 42);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(145, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Location = new System.Drawing.Point(221, 44);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(445, 20);
            this.txtSearchBox.TabIndex = 2;
            this.txtSearchBox.Text = "خدمات عمومی";
            this.txtSearchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchBox_KeyPress);
            // 
            // lblTotalSearchCount
            // 
            this.lblTotalSearchCount.AutoSize = true;
            this.lblTotalSearchCount.Location = new System.Drawing.Point(22, 75);
            this.lblTotalSearchCount.Name = "lblTotalSearchCount";
            this.lblTotalSearchCount.Size = new System.Drawing.Size(34, 13);
            this.lblTotalSearchCount.TabIndex = 3;
            this.lblTotalSearchCount.Text = "Total:";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 141;
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.Location = new System.Drawing.Point(591, 70);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "کپی";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cmbxFiles
            // 
            this.cmbxFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFiles.FormattingEnabled = true;
            this.cmbxFiles.Location = new System.Drawing.Point(16, 17);
            this.cmbxFiles.Name = "cmbxFiles";
            this.cmbxFiles.Size = new System.Drawing.Size(650, 21);
            this.cmbxFiles.TabIndex = 5;
            this.cmbxFiles.SelectedIndexChanged += new System.EventHandler(this.cmbxFiles_SelectedIndexChanged);
            // 
            // ucTaxStuff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbxFiles);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lblTotalSearchCount);
            this.Controls.Add(this.txtSearchBox);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.listViewEx21);
            this.Name = "ucTaxStuff";
            this.Size = new System.Drawing.Size(683, 597);
            this.Load += new System.EventHandler(this.ucTaxStuff_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GUI.GUIHelper.ListViewEx2 listViewEx21;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.Label lblTotalSearchCount;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ComboBox cmbxFiles;
    }
}
