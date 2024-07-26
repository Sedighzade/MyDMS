namespace MyDMS.Forms.SecretaraitForms
{
    partial class frmNewLetter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewLetter));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.btnAddNewReceipient = new System.Windows.Forms.Button();
            this.cmbxOrgs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLetterText = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtSend = new System.Windows.Forms.DateTimePicker();
            this.chkbxEditCreatonDate = new System.Windows.Forms.CheckBox();
            this.dtCreation = new System.Windows.Forms.DateTimePicker();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAttachedFile = new System.Windows.Forms.TextBox();
            this.lblBrwoseAttachedFile = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAdd.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnAdd.Location = new System.Drawing.Point(607, 48);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "افزودن";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.Location = new System.Drawing.Point(607, 86);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtSubject.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSubject.Location = new System.Drawing.Point(140, 104);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(421, 31);
            this.txtSubject.TabIndex = 3;
            // 
            // btnAddNewReceipient
            // 
            this.btnAddNewReceipient.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddNewReceipient.FlatAppearance.BorderSize = 0;
            this.btnAddNewReceipient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewReceipient.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewReceipient.Image")));
            this.btnAddNewReceipient.Location = new System.Drawing.Point(567, 60);
            this.btnAddNewReceipient.Name = "btnAddNewReceipient";
            this.btnAddNewReceipient.Size = new System.Drawing.Size(27, 23);
            this.btnAddNewReceipient.TabIndex = 2;
            this.btnAddNewReceipient.UseVisualStyleBackColor = true;
            this.btnAddNewReceipient.Click += new System.EventHandler(this.btnAddNewReceipient_Click);
            // 
            // cmbxOrgs
            // 
            this.cmbxOrgs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmbxOrgs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxOrgs.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbxOrgs.FormattingEnabled = true;
            this.cmbxOrgs.Location = new System.Drawing.Point(140, 55);
            this.cmbxOrgs.Name = "cmbxOrgs";
            this.cmbxOrgs.Size = new System.Drawing.Size(421, 32);
            this.cmbxOrgs.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(12, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "شماره دبیرخانه مقصد";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(65, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "تاریخ ایجاد";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(99, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "متن";
            // 
            // txtLetterText
            // 
            this.txtLetterText.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtLetterText.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtLetterText.Location = new System.Drawing.Point(140, 250);
            this.txtLetterText.Multiline = true;
            this.txtLetterText.Name = "txtLetterText";
            this.txtLetterText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLetterText.Size = new System.Drawing.Size(421, 83);
            this.txtLetterText.TabIndex = 7;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtCode.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCode.Location = new System.Drawing.Point(140, 341);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(421, 31);
            this.txtCode.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(86, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "گیرنده";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(62, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 24);
            this.label5.TabIndex = 15;
            this.label5.Text = "تاریخ ارسال";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.Location = new System.Drawing.Point(86, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "موضوع";
            // 
            // dtSend
            // 
            this.dtSend.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dtSend.CalendarFont = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dtSend.CustomFormat = "  yyyy-MM-dd        HH:mm";
            this.dtSend.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dtSend.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSend.Location = new System.Drawing.Point(140, 206);
            this.dtSend.Name = "dtSend";
            this.dtSend.Size = new System.Drawing.Size(421, 31);
            this.dtSend.TabIndex = 6;
            // 
            // chkbxEditCreatonDate
            // 
            this.chkbxEditCreatonDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkbxEditCreatonDate.AutoSize = true;
            this.chkbxEditCreatonDate.Location = new System.Drawing.Point(567, 158);
            this.chkbxEditCreatonDate.Name = "chkbxEditCreatonDate";
            this.chkbxEditCreatonDate.Size = new System.Drawing.Size(51, 21);
            this.chkbxEditCreatonDate.TabIndex = 5;
            this.chkbxEditCreatonDate.Text = "ویرایش";
            this.chkbxEditCreatonDate.UseVisualStyleBackColor = true;
            this.chkbxEditCreatonDate.CheckedChanged += new System.EventHandler(this.chkbxEditCreatonDate_CheckedChanged);
            // 
            // dtCreation
            // 
            this.dtCreation.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dtCreation.CalendarFont = new System.Drawing.Font("B Nazanin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dtCreation.CustomFormat = "  yyyy-MM-dd        HH:mm";
            this.dtCreation.Enabled = false;
            this.dtCreation.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dtCreation.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtCreation.Location = new System.Drawing.Point(140, 149);
            this.dtCreation.Name = "dtCreation";
            this.dtCreation.Size = new System.Drawing.Size(421, 31);
            this.dtCreation.TabIndex = 4;
            // 
            // txtSerial
            // 
            this.txtSerial.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtSerial.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSerial.Location = new System.Drawing.Point(140, 9);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(421, 31);
            this.txtSerial.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.Location = new System.Drawing.Point(32, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 24);
            this.label7.TabIndex = 4;
            this.label7.Text = "شماره سریال نامه";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(58, 381);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 24);
            this.label8.TabIndex = 16;
            this.label8.Text = "فایل ضمیمه";
            // 
            // txtAttachedFile
            // 
            this.txtAttachedFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtAttachedFile.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtAttachedFile.Location = new System.Drawing.Point(140, 378);
            this.txtAttachedFile.Name = "txtAttachedFile";
            this.txtAttachedFile.Size = new System.Drawing.Size(421, 31);
            this.txtAttachedFile.TabIndex = 17;
            // 
            // lblBrwoseAttachedFile
            // 
            this.lblBrwoseAttachedFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBrwoseAttachedFile.AutoSize = true;
            this.lblBrwoseAttachedFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBrwoseAttachedFile.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBrwoseAttachedFile.Location = new System.Drawing.Point(563, 381);
            this.lblBrwoseAttachedFile.Name = "lblBrwoseAttachedFile";
            this.lblBrwoseAttachedFile.Size = new System.Drawing.Size(21, 26);
            this.lblBrwoseAttachedFile.TabIndex = 18;
            this.lblBrwoseAttachedFile.Text = "...";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.button1.Location = new System.Drawing.Point(590, 378);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 19;
            this.button1.Text = "باز کردن فال";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmNewLetter
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(694, 469);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblBrwoseAttachedFile);
            this.Controls.Add(this.txtAttachedFile);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtCreation);
            this.Controls.Add(this.chkbxEditCreatonDate);
            this.Controls.Add(this.dtSend);
            this.Controls.Add(this.txtLetterText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbxOrgs);
            this.Controls.Add(this.btnAddNewReceipient);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("B Nazanin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewLetter";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "نامه جدید";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Button btnAddNewReceipient;
        private System.Windows.Forms.ComboBox cmbxOrgs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLetterText;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtSend;
        private System.Windows.Forms.CheckBox chkbxEditCreatonDate;
        private System.Windows.Forms.DateTimePicker dtCreation;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAttachedFile;
        private System.Windows.Forms.Label lblBrwoseAttachedFile;
        private System.Windows.Forms.Button button1;
    }
}