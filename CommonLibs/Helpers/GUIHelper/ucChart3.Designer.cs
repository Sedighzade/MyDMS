
namespace PNB.GUI.GUIHelper
{
    partial class ucChart3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucChart3));
            this.cmsZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtnShowCursor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiXAxisZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiYAxisZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeperateCharts = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnPan = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPointer = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.cms.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsZoomOut
            // 
            this.cmsZoomOut.Name = "cmsZoomOut";
            this.cmsZoomOut.Size = new System.Drawing.Size(129, 22);
            this.cmsZoomOut.Text = "Zoom Out";
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsZoomOut});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(130, 26);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnShowCursor});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(92, 22);
            this.toolStripButton1.Text = "Apearance";
            // 
            // tsbtnShowCursor
            // 
            this.tsbtnShowCursor.CheckOnClick = true;
            this.tsbtnShowCursor.Name = "tsbtnShowCursor";
            this.tsbtnShowCursor.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsbtnShowCursor.Size = new System.Drawing.Size(160, 22);
            this.tsbtnShowCursor.Text = "Show Cusror";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiXAxisZoom,
            this.tsmiYAxisZoom,
            this.toolStripSeparator1,
            this.tsmiZoomOut});
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton2.Text = "Zoom";
            // 
            // tsmiXAxisZoom
            // 
            this.tsmiXAxisZoom.CheckOnClick = true;
            this.tsmiXAxisZoom.Name = "tsmiXAxisZoom";
            this.tsmiXAxisZoom.Size = new System.Drawing.Size(141, 22);
            this.tsmiXAxisZoom.Text = "X Axis Zoom";
            // 
            // tsmiYAxisZoom
            // 
            this.tsmiYAxisZoom.CheckOnClick = true;
            this.tsmiYAxisZoom.Name = "tsmiYAxisZoom";
            this.tsmiYAxisZoom.Size = new System.Drawing.Size(141, 22);
            this.tsmiYAxisZoom.Text = "Y Axis Zoom";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // tsmiZoomOut
            // 
            this.tsmiZoomOut.Name = "tsmiZoomOut";
            this.tsmiZoomOut.Size = new System.Drawing.Size(141, 22);
            this.tsmiZoomOut.Text = "Zoom Out";
            // 
            // tsmiSeperateCharts
            // 
            this.tsmiSeperateCharts.CheckOnClick = true;
            this.tsmiSeperateCharts.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSeperateCharts.Image")));
            this.tsmiSeperateCharts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiSeperateCharts.Name = "tsmiSeperateCharts";
            this.tsmiSeperateCharts.Size = new System.Drawing.Size(109, 22);
            this.tsmiSeperateCharts.Text = "Seperate Charts";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnPan
            // 
            this.tsbtnPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPan.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPan.Image")));
            this.tsbtnPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPan.Name = "tsbtnPan";
            this.tsbtnPan.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPan.Text = "toolStripButton3";
            // 
            // tsbtnPointer
            // 
            this.tsbtnPointer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnPointer.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPointer.Image")));
            this.tsbtnPointer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPointer.Name = "tsbtnPointer";
            this.tsbtnPointer.Size = new System.Drawing.Size(23, 22);
            this.tsbtnPointer.Text = "toolStripButton4";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Enabled = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.tsmiSeperateCharts,
            this.toolStripSeparator4,
            this.tsbtnPan,
            this.tsbtnPointer,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(733, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.checkedListBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.formsPlot1);
            this.splitContainer1.Size = new System.Drawing.Size(733, 610);
            this.splitContainer1.SplitterDistance = 145;
            this.splitContainer1.TabIndex = 4;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(145, 610);
            this.checkedListBox1.TabIndex = 1;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(0, 0);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(584, 610);
            this.formsPlot1.TabIndex = 0;
            // 
            // ucChart3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ucChart3";
            this.Size = new System.Drawing.Size(733, 635);
            this.cms.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem cmsZoomOut;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem tsbtnShowCursor;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem tsmiXAxisZoom;
        private System.Windows.Forms.ToolStripMenuItem tsmiYAxisZoom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiZoomOut;
        private System.Windows.Forms.ToolStripButton tsmiSeperateCharts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnPan;
        private System.Windows.Forms.ToolStripButton tsbtnPointer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}
