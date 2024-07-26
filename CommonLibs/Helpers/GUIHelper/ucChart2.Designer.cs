
namespace PNB.GUI.GUIHelper
{
    partial class ucChart2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucChart2));
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmbx = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtnShowCursor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiYCursorTracking = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiXCursorTracking = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiMultipleYAxis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiXAxisZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiYAxisZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSeperateCharts = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnPan = new System.Windows.Forms.ToolStripButton();
            this.tsbtnPointer = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.cms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(3, 27);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.SelectedObject = this.chart1;
            this.propertyGrid1.Size = new System.Drawing.Size(285, 430);
            this.propertyGrid1.TabIndex = 2;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Maroon;
            this.chart1.ContextMenuStrip = this.cms;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(577, 457);
            this.chart1.TabIndex = 3;
            // 
            // cms
            // 
            this.cms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsZoomOut});
            this.cms.Name = "cms";
            this.cms.Size = new System.Drawing.Size(130, 26);
            // 
            // cmsZoomOut
            // 
            this.cmsZoomOut.Name = "cmsZoomOut";
            this.cmsZoomOut.Size = new System.Drawing.Size(129, 22);
            this.cmsZoomOut.Text = "Zoom Out";
            this.cmsZoomOut.Click += new System.EventHandler(this.cmsZoomOut_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cmbx);
            this.splitContainer1.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(873, 457);
            this.splitContainer1.SplitterDistance = 577;
            this.splitContainer1.TabIndex = 4;
            // 
            // cmbx
            // 
            this.cmbx.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbx.FormattingEnabled = true;
            this.cmbx.Location = new System.Drawing.Point(0, 0);
            this.cmbx.Name = "cmbx";
            this.cmbx.Size = new System.Drawing.Size(292, 21);
            this.cmbx.TabIndex = 3;
            this.cmbx.SelectedIndexChanged += new System.EventHandler(this.cmbx_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(873, 588);
            this.splitContainer2.SplitterDistance = 528;
            this.splitContainer2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(873, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.tsmiSeperateCharts,
            this.toolStripSeparator4,
            this.tsbtnPan,
            this.tsbtnPointer,
            this.toolStripTextBox1,
            this.toolStripTextBox2,
            this.toolStripTextBox3,
            this.toolStripTextBox4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(873, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnShowCursor,
            this.toolStripSeparator2,
            this.tsmiYCursorTracking,
            this.tsmiXCursorTracking,
            this.toolStripSeparator3,
            this.tsmiMultipleYAxis});
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
            this.tsbtnShowCursor.Size = new System.Drawing.Size(166, 22);
            this.tsbtnShowCursor.Text = "Show Cusror";
            this.tsbtnShowCursor.Click += new System.EventHandler(this.tsbtnShowCursor_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // tsmiYCursorTracking
            // 
            this.tsmiYCursorTracking.CheckOnClick = true;
            this.tsmiYCursorTracking.Name = "tsmiYCursorTracking";
            this.tsmiYCursorTracking.Size = new System.Drawing.Size(166, 22);
            this.tsmiYCursorTracking.Text = "Y Cursor Tracknig";
            // 
            // tsmiXCursorTracking
            // 
            this.tsmiXCursorTracking.CheckOnClick = true;
            this.tsmiXCursorTracking.Name = "tsmiXCursorTracking";
            this.tsmiXCursorTracking.Size = new System.Drawing.Size(166, 22);
            this.tsmiXCursorTracking.Text = "X Cursor Tracknig";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(163, 6);
            // 
            // tsmiMultipleYAxis
            // 
            this.tsmiMultipleYAxis.CheckOnClick = true;
            this.tsmiMultipleYAxis.Name = "tsmiMultipleYAxis";
            this.tsmiMultipleYAxis.Size = new System.Drawing.Size(166, 22);
            this.tsmiMultipleYAxis.Text = "Multiple Y Axis";
            this.tsmiMultipleYAxis.Click += new System.EventHandler(this.tsmiMultipleYAxis_Click);
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
            this.tsmiXAxisZoom.Click += new System.EventHandler(this.tsmiXAxisZoom_Click);
            // 
            // tsmiYAxisZoom
            // 
            this.tsmiYAxisZoom.CheckOnClick = true;
            this.tsmiYAxisZoom.Name = "tsmiYAxisZoom";
            this.tsmiYAxisZoom.Size = new System.Drawing.Size(141, 22);
            this.tsmiYAxisZoom.Text = "Y Axis Zoom";
            this.tsmiYAxisZoom.Click += new System.EventHandler(this.tsmiYAxisZoom_Click);
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
            this.tsmiZoomOut.Click += new System.EventHandler(this.tsmiZoomOut_Click);
            // 
            // tsmiSeperateCharts
            // 
            this.tsmiSeperateCharts.Image = ((System.Drawing.Image)(resources.GetObject("tsmiSeperateCharts.Image")));
            this.tsmiSeperateCharts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiSeperateCharts.Name = "tsmiSeperateCharts";
            this.tsmiSeperateCharts.Size = new System.Drawing.Size(109, 22);
            this.tsmiSeperateCharts.Text = "Seperate Charts";
            this.tsmiSeperateCharts.Click += new System.EventHandler(this.tsmiSeperateCharts_Click);
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
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(100, 25);
            // 
            // ucChart2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.splitContainer2);
            this.Name = "ucChart2";
            this.Size = new System.Drawing.Size(873, 588);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.cms.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PropertyGrid propertyGrid1;

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbx;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem tsbtnShowCursor;
        private System.Windows.Forms.ToolStripMenuItem tsmiYCursorTracking;
        private System.Windows.Forms.ToolStripMenuItem tsmiXCursorTracking;
        private System.Windows.Forms.ToolStripMenuItem tsmiMultipleYAxis;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton2;
        private System.Windows.Forms.ToolStripMenuItem tsmiXAxisZoom;
        private System.Windows.Forms.ToolStripMenuItem tsmiYAxisZoom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiZoomOut;
        private System.Windows.Forms.ContextMenuStrip cms;
        private System.Windows.Forms.ToolStripMenuItem cmsZoomOut;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsmiSeperateCharts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbtnPan;
        private System.Windows.Forms.ToolStripButton tsbtnPointer;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
    }
}
