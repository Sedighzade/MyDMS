
namespace PNB.Data
{
    partial class frmDBSuite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDBSuite));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQ = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.cmbxFreq = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 128);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(852, 321);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtCS
            // 
            this.txtCS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCS.Location = new System.Drawing.Point(118, 462);
            this.txtCS.Name = "txtCS";
            this.txtCS.Size = new System.Drawing.Size(746, 20);
            this.txtCS.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connection String:";
            // 
            // txtQ
            // 
            this.txtQ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQ.Location = new System.Drawing.Point(12, 46);
            this.txtQ.Multiline = true;
            this.txtQ.Name = "txtQ";
            this.txtQ.Size = new System.Drawing.Size(761, 76);
            this.txtQ.TabIndex = 3;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecute.Location = new System.Drawing.Point(789, 12);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 74);
            this.btnExecute.TabIndex = 4;
            this.btnExecute.Text = "Execute Query";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cmbxFreq
            // 
            this.cmbxFreq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbxFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxFreq.FormattingEnabled = true;
            this.cmbxFreq.Items.AddRange(new object[] {
            "----- Select a query -----",
            "SELECT * FROM INFORMATION_SCHEMA.TABLES",
            "SELECT obj.name, cols.name as columnname FROM br100.sys.objects as obj inner join" +
                " br100.sys.columns as cols on obj.object_id = cols.object_id where obj.type=\'U\'",
            "sp_help \'SessionData\'",
            resources.GetString("cmbxFreq.Items"),
            "DBCC SHRINKDATABASE  (0)",
            "SELECT * FROM SessionData",
            "DELETE FROM NumericData",
            "DELETE FROM TextData",
            "DELETE FROM BooleanData",
            "DELETE FROM SessionData"});
            this.cmbxFreq.Location = new System.Drawing.Point(98, 17);
            this.cmbxFreq.Name = "cmbxFreq";
            this.cmbxFreq.Size = new System.Drawing.Size(675, 21);
            this.cmbxFreq.TabIndex = 5;
            this.cmbxFreq.SelectedIndexChanged += new System.EventHandler(this.cmbxFreq_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Most Frequent";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(789, 92);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmDBSuite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 488);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbxFreq);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtQ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCS);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmDBSuite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DB Suite";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQ;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ComboBox cmbxFreq;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
    }
}