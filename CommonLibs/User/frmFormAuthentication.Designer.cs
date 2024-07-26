namespace PNB.Lib.UserMgmt
{
    partial class frmFormAuthentication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFormAuthentication));
            this.txtUN = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pbLock = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbShutdown = new System.Windows.Forms.PictureBox();
            this.lblExtraData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShutdown)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUN
            // 
            this.txtUN.Location = new System.Drawing.Point(108, 41);
            this.txtUN.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtUN.Name = "txtUN";
            this.txtUN.Size = new System.Drawing.Size(220, 26);
            this.txtUN.TabIndex = 0;
            this.txtUN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUN_KeyPress);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(108, 96);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(220, 26);
            this.txtPass.TabIndex = 1;
            this.txtPass.UseSystemPasswordChar = true;
            this.txtPass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "نام کاربری";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "رمز عبور";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(129, 156);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(166, 43);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "ورود";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pbLock
            // 
            this.pbLock.Image = ((System.Drawing.Image)(resources.GetObject("pbLock.Image")));
            this.pbLock.Location = new System.Drawing.Point(37, 59);
            this.pbLock.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbLock.Name = "pbLock";
            this.pbLock.Size = new System.Drawing.Size(48, 48);
            this.pbLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLock.TabIndex = 3;
            this.pbLock.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(111, 99);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 20);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // pbShutdown
            // 
            this.pbShutdown.Image = ((System.Drawing.Image)(resources.GetObject("pbShutdown.Image")));
            this.pbShutdown.Location = new System.Drawing.Point(407, 179);
            this.pbShutdown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbShutdown.Name = "pbShutdown";
            this.pbShutdown.Size = new System.Drawing.Size(32, 32);
            this.pbShutdown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbShutdown.TabIndex = 5;
            this.pbShutdown.TabStop = false;
            this.pbShutdown.Click += new System.EventHandler(this.pbShutdown_Click);
            // 
            // lblExtraData
            // 
            this.lblExtraData.Location = new System.Drawing.Point(7, 203);
            this.lblExtraData.Name = "lblExtraData";
            this.lblExtraData.Size = new System.Drawing.Size(133, 16);
            this.lblExtraData.TabIndex = 6;
            // 
            // frmFormAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 224);
            this.ControlBox = false;
            this.Controls.Add(this.lblExtraData);
            this.Controls.Add(this.pbShutdown);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pbLock);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUN);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmFormAuthentication";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ورود";
            //this.Load += new System.EventHandler(this.frmFormAuthentication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShutdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUN;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pbLock;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pbShutdown;
        private System.Windows.Forms.Label lblExtraData;
    }
}