using PNB.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PNB.GUI.GUIHelper
{
    public partial class ucChart2 : UserControl
    {
        /*
          
        Improve Chart Performance
          https://docs.microsoft.com/en-gb/archive/blogs/alexgor/microsoft-chart-control-how-to-improve-chart-performance

           1 - Markers doesn't work with FastLine chart Type.
         
         */
        ChartArea ca;
        Legend lg;
        public ucChart2()
        {
            InitializeComponent();


            chart1.BackGradientStyle = GradientStyle.TopBottom;
            chart1.BackSecondaryColor = Color.LightGray;

            ///Chart Area
            ca = new ChartArea();
            ca.BackGradientStyle = GradientStyle.TopBottom;
            ca.BackSecondaryColor = Color.LightGray;
            ca.CursorX.IsUserSelectionEnabled = ca.CursorY.IsUserSelectionEnabled = true;

            //Cursors
            ca.CursorX.LineColor = ca.CursorY.LineColor = Color.Red;

            lg = new Legend();
            lg.Docking = Docking.Bottom;
            //lg.BackColor = Color.Transparent;
            chart1.Legends.Add(lg);

            //Scrollbar
            chart1.ChartAreas.Add(ca);

            string hh = chart1.ToString();
            cmbx.Items.Add(chart1);
            cmbx.Items.Add(ca);
            cmbx.Items.Add(ca.CursorX);
            cmbx.Items.Add(ca.CursorY);
            cmbx.Items.Add(ca.AxisX);
            cmbx.Items.Add(ca.AxisY);
            cmbx.Items.Add(ca.AxisX.ScaleView);
            cmbx.Items.Add(ca.AxisY.ScaleView);
            cmbx.Items.Add(lg);
            //cmbx.SelectedItem = chart1;
            cmbx.SelectedIndex = 0;

            chart1.MouseMove += Chart1_MouseMove;
            chart1.MouseClick += Chart1_MouseClick;
            chart1.MouseWheel += Chart1_MouseWheel;
            chart1.MouseEnter += delegate { this.chart1.Focus(); };
            chart1.MouseLeave += delegate { this.chart1.Parent.Focus(); };

            ca.CursorX.Interval = ca.CursorY.Interval = 0;

            toolStripTextBox1.Text = ca.AxisX.Minimum.ToString();
            toolStripTextBox2.Text = ca.AxisX.Maximum.ToString();
            toolStripTextBox3.Text = ca.AxisY.Minimum.ToString();
            toolStripTextBox4.Text = ca.AxisY.Maximum.ToString();
       }
        private class ZoomFrame
        {
            public double XStart { get; set; }
            public double XFinish { get; set; }
            public double YStart { get; set; }
            public double YFinish { get; set; }
        }
        private const float CZoomScale = 2f;
        private int FZoomLevel = 0;
        int method = 1;

        private void Chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            label1.Text = e.Delta.ToString();
            if (method == 1)
            {
                try
                {
                    if (e.Delta < 0)
                    {
                        DoZoomOut();
                    }

                    if (e.Delta > 0)
                    {
                        double xMin = ca.AxisX.ScaleView.ViewMinimum;
                        double xMax = ca.AxisX.ScaleView.ViewMaximum;
                        double yMin = ca.AxisY.ScaleView.ViewMinimum;
                        double yMax = ca.AxisY.ScaleView.ViewMaximum;

                        double posXStart = ca.AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / CZoomScale;
                        double posXFinish = ca.AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / CZoomScale;
                        double posYStart = ca.AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / CZoomScale;
                        double posYFinish = ca.AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / CZoomScale;

                        ca.AxisX.ScaleView.Zoom(posXStart, posXFinish);
                        ca.AxisY.ScaleView.Zoom(posYStart, posYFinish);
                    }
                }
                catch { }
            }
            else if (method == 2)
            {
                try
                {
                    Axis xAxis = ca.AxisX;
                    double xMin = xAxis.ScaleView.ViewMinimum;
                    double xMax = xAxis.ScaleView.ViewMaximum;
                    double xPixelPos = xAxis.PixelPositionToValue(e.Location.X);

                    if (e.Delta < 0 && FZoomLevel > 0)
                    {
                        // Scrolled down, meaning zoom out
                        if (--FZoomLevel <= 0)
                        {
                            FZoomLevel = 0;
                            xAxis.ScaleView.ZoomReset();
                        }
                        else
                        {
                            double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) * CZoomScale, 0);
                            double xEndPos = Math.Min(xStartPos + (xMax - xMin) * CZoomScale, xAxis.Maximum);
                            xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                        }
                    }
                    else if (e.Delta > 0)
                    {
                        // Scrolled up, meaning zoom in
                        double xStartPos = Math.Max(xPixelPos - (xPixelPos - xMin) / CZoomScale, 0);
                        double xEndPos = Math.Min(xStartPos + (xMax - xMin) / CZoomScale, xAxis.Maximum);
                        xAxis.ScaleView.Zoom(xStartPos, xEndPos);
                        FZoomLevel++;
                    }
                }
                catch { }
            }
        }

        private void Chart1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                DoZoomOut();
        }

        public void Add(object arg)
        {
            cmbx.Items.Add(arg);
        }


        private void Chart1_MouseMove(object sender, MouseEventArgs e)
        {
            double xV = 0, yV = 0;
            try
            {
                if (tsbtnShowCursor.Checked)
                {
                    PointF pf = new PointF(e.X, e.Y);

                    ca.CursorX.SetCursorPixelPosition(pf, true);
                    ca.CursorY.SetCursorPixelPosition(pf, true);

                    xV = ca.AxisX.PixelPositionToValue(ca.CursorX.Position);
                    yV = ca.AxisY.PixelPositionToValue(ca.CursorY.Position);

                    foreach (Series s in chart1.Series)
                        foreach (DataPoint dp in s.Points)
                        {
                            if (((int)dp.XValue == (int)ca.CursorX.Position && tsmiXCursorTracking.Checked) ||
                                    ((int)dp.YValues[0] == (int)ca.CursorY.Position && tsmiYCursorTracking.Checked))
                            {
                                dp.MarkerStyle = MarkerStyle.Circle;
                                dp.MarkerSize = 10;
                                dp.MarkerColor = Color.Red;
                            }
                            else
                                dp.MarkerStyle = MarkerStyle.None;
                        }
                }
                label1.Text = string.Format("{5}\nMouse Location: {0}\nCursors: X={1:F2} Y={2:F2}\nValue: X={3:F2} Y={4:F2}"
                    , e.Location, ca.CursorX.Position, ca.CursorY.Position, xV, yV, ca.AxisX.ScaleView.ViewMaximum);
            }
            catch (Exception ee) { Logger.Debug(ee.Message); }
        }
        void Message(string msg)
        {
            label1.Text = msg;
            Logger.Debug(msg);
        }
        static public Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
        }

        #region Properties
        public int ScaleXView { set { ca.AxisX.ScaleView.Size = value; } }
        public int ScaleYView { set { ca.AxisY.ScaleView.Size = value; } }
        public bool DisplayChart { set { this.propertyGrid1.Visible = value; } }
        public Chart CHART { get { return chart1; } }

        #endregion

        public void AddPoints(SeriesChartType sct, double[] X, ChartValueType ct, double[,] Y)
        {
            List<Series> series = new List<Series>();
            int rowC = Y.GetLength(0);

            for (int row = 0; row < rowC; row++)
            {
                Series s1 = new Series();
                s1.Name = "Series " + row.ToString();
                series.Add(s1);
                cmbx.Items.Add(s1);
                chart1.Series.Add(s1);

                s1.ChartType = sct;
                s1.XValueType = ct;

                for (int i = 0; i < X.Length; i++)
                {
                    DataPoint dp = new DataPoint(X[i], Y[row, i]);
                    s1.Points.Add(dp);
                }
            }
        }
        public void AddPoints2(SeriesChartType sct, double[] X, ChartValueType ct, double[,] Y)
        {
            List<Series> series = new List<Series>();
            int rowC = Y.GetLength(0);

            for (int row = 0; row < rowC; row++)
            {
                Series s1 = new Series();
                s1.Name = "Series " + row.ToString();
                series.Add(s1);
                cmbx.Items.Add(s1);
                chart1.Series.Add(s1);

                s1.ChartType = sct;
                s1.XValueType = ct;

                for (int i = 0; i < X.Length; i++)
                {
                    DataPoint dp = new DataPoint(X[i], Y[row, i]);
                    s1.Points.Add(dp);
                }
            }
        }


        #region Appearance
        private void tsbtnShowCursor_Click(object sender, EventArgs e)
        {
            tsmiXCursorTracking.Enabled = tsmiYCursorTracking.Enabled = tsbtnShowCursor.Checked;
            if (!tsbtnShowCursor.Checked)
            {
                ca.CursorX.Position = ca.CursorY.Position = double.NaN;
            }
        }
        private void cmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = cmbx.SelectedItem;
        }

        private void tsmiMultipleYAxis_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void cmsZoomOut_Click(object sender, EventArgs e)
        {
            DoZoomOut();
        }

        #region Zoom
        private void tsmiXAxisZoom_Click(object sender, EventArgs e)
        {

        }
        private void tsmiYAxisZoom_Click(object sender, EventArgs e)
        {

        }
        private void tsmiZoomOut_Click(object sender, EventArgs e)
        {

            DoZoomOut();
        }

        #endregion
        private void DoZoomOut()
        {
            ca.AxisY.ScaleView.ZoomReset(0);
            ca.AxisX.ScaleView.ZoomReset(0);
        }

        private void tsmiSeperateCharts_Click(object sender, EventArgs e)
        {
            tsmiSeperateCharts.Text = tsmiSeperateCharts.Checked ? "Combine Charts" : "Seperate Charts";
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}


