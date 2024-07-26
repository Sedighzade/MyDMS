namespace PNB.Lib.UserMgmt
{
    partial class frmRFAuthentication
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRFAuthentication));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.eeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileBypass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileAuthenticate = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUserI = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCycle = new System.Windows.Forms.Label();
            this.pbShutdown = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShutdown)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eeeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(280, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // eeeToolStripMenuItem
            // 
            this.eeeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileBypass,
            this.mnuFileAuthenticate});
            this.eeeToolStripMenuItem.Name = "eeeToolStripMenuItem";
            this.eeeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.eeeToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.eeeToolStripMenuItem.Text = "File";
            // 
            // mnuFileBypass
            // 
            this.mnuFileBypass.Name = "mnuFileBypass";
            this.mnuFileBypass.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.mnuFileBypass.Size = new System.Drawing.Size(161, 22);
            this.mnuFileBypass.Text = "Bypass";
            this.mnuFileBypass.Click += new System.EventHandler(this.mnuFileBypass_Click);
            // 
            // mnuFileAuthenticate
            // 
            this.mnuFileAuthenticate.Name = "mnuFileAuthenticate";
            this.mnuFileAuthenticate.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuFileAuthenticate.Size = new System.Drawing.Size(161, 22);
            this.mnuFileAuthenticate.Text = "Authenticate";
            this.mnuFileAuthenticate.Click += new System.EventHandler(this.mnuFileAuthenticate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblUserI
            // 
            this.lblUserI.AutoSize = true;
            this.lblUserI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserI.Location = new System.Drawing.Point(146, 30);
            this.lblUserI.Name = "lblUserI";
            this.lblUserI.Size = new System.Drawing.Size(55, 20);
            this.lblUserI.TabIndex = 3;
            this.lblUserI.Text = "Name";
            // 
            // lblName
            // 
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(151, 57);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(117, 35);
            this.lblName.TabIndex = 5;
            // 
            // lblCycle
            // 
            this.lblCycle.AutoSize = true;
            this.lblCycle.Location = new System.Drawing.Point(14, 173);
            this.lblCycle.Name = "lblCycle";
            this.lblCycle.Size = new System.Drawing.Size(63, 13);
            this.lblCycle.TabIndex = 7;
            this.lblCycle.Text = "Cycle: 0000";
            // 
            // pbShutdown
            // 
            this.pbShutdown.Image = ((System.Drawing.Image)(resources.GetObject("pbShutdown.Image")));
            this.pbShutdown.Location = new System.Drawing.Point(236, 160);
            this.pbShutdown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbShutdown.Name = "pbShutdown";
            this.pbShutdown.Size = new System.Drawing.Size(32, 32);
            this.pbShutdown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbShutdown.TabIndex = 8;
            this.pbShutdown.TabStop = false;
            this.pbShutdown.Click += new System.EventHandler(this.pbShutdown_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 9;
            // 
            // frmRFAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(280, 205);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbShutdown);
            this.Controls.Add(this.lblCycle);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblUserI);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmRFAuthentication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RF Authentication";
            this.Load += new System.EventHandler(this.frmRFAuthentication_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmRFAuthentication_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShutdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem eeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileBypass;
        private System.Windows.Forms.ToolStripMenuItem mnuFileAuthenticate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblUserI;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCycle;
        private System.Windows.Forms.PictureBox pbShutdown;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}