using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PNB.GUI.GUIHelper
{
    /// <summary>
    /// https://www.codeproject.com/Articles/1261160/Smooth-Zoom-Round-Numbers-in-MS-Chart 
    /// </summary>
    public partial class ucChart : UserControl
    {
        bool useNiceRoundNumbers = true;
        bool zoomingNow = false;
        bool useGDI32 = true;
        Rectangle zoomRect;

        public ucChart()
        {
            InitializeComponent();

            //Hook the mouse events to implement the zoom
            chart1.MouseDown += chart_MouseDown;
            chart1.MouseMove += chart_MouseMove;
            chart1.MouseUp += chart_MouseUp;
        }

        private void chart_MouseDown(object sender, MouseEventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;
            this.Focus();
            //Test for Ctrl + Left Single Click to start displaying selection box
            if ((e.Button == MouseButtons.Left) && (e.Clicks == 1) &&
                    ((ModifierKeys & Keys.Control) != 0) && sender is Chart)
            {
                zoomingNow = true;
                zoomRect.Location = e.Location;
                zoomRect.Width = zoomRect.Height = 0;
                DrawZoomRect(); //Draw the new selection rect
            }
            this.Focus();
        }
        private void chart_MouseUp(object sender, MouseEventArgs e)
        {
            if (zoomingNow && e.Button == MouseButtons.Left)
            {
                DrawZoomRect(); //Redraw the selection 
                                //rect, which erases it
                if ((zoomRect.Width != 0) && (zoomRect.Height != 0))
                {
                    //Just in case the selection was dragged from lower right to upper left
                    zoomRect = new Rectangle(Math.Min(zoomRect.Left, zoomRect.Right),
                            Math.Min(zoomRect.Top, zoomRect.Bottom),
                            Math.Abs(zoomRect.Width),
                            Math.Abs(zoomRect.Height));
                    ZoomInToZoomRect(); //no Shift so Zoom in.
                }
                zoomingNow = false;
            }
        }
        private void chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (zoomingNow)
            {
                DrawZoomRect(); //Redraw the old selection 
                                //rect, which erases it
                zoomRect.Width = e.X - zoomRect.Left;
                zoomRect.Height = e.Y - zoomRect.Top;
                DrawZoomRect(); //Draw the new selection rect
            }
        }

        private void DrawZoomRect()
        {
            Pen pen = new Pen(Color.Black, 1.0f);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            if (useGDI32)
            {
                //This is so much smoother than ControlPaint.DrawReversibleFrame
                GDI32.DrawXORRectangle(chart1.CreateGraphics(), pen, zoomRect);
            }
            else
            {
                Rectangle screenRect = chart1.RectangleToScreen(zoomRect);
                ControlPaint.DrawReversibleFrame(screenRect, chart1.BackColor, FrameStyle.Dashed);
            }
        }
        /// <summary>
        /// This method zooms in to the area contained within the portion of zoomRect 
        /// that overlaps the chart innerPlotRectangle. zoomRect is positioned in the client rectangle 
        /// of the chart in which the zoom was initiated with a Left MouseDown event. 
        /// </summary>
        private void ZoomInToZoomRect()
        {
            if (zoomRect.Width == 0 || zoomRect.Height == 0)
                return;

            Rectangle r = zoomRect;

            ChartScaleData csd = chart1.Tag as ChartScaleData;
            //Get overlap of zoomRect and the innerPlotRectangle
            Rectangle ipr = csd.innerPlotRectangle;
            if (!r.IntersectsWith(ipr))
                return;
            r.Intersect(ipr);
            if (!csd.isZoomed)
            {
                csd.isZoomed = true;
                csd.UpdateAxisBaseData();
            }

            SetZoomAxisScale(chart1.ChartAreas[0].AxisX, r.Left, r.Right);
            SetZoomAxisScale(chart1.ChartAreas[0].AxisY, r.Bottom, r.Top);
        }

        /// <summary>
        /// Sets the axis parameters to an unzoomed state showing all data, 
        /// and nice round numbers and intervals for the axis labels
        /// Note: at this stage the axis is unchanged, and this has not been tested with reversed axes.
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="pxLow">low pixel position in chart client rectangle coordinates</param>
        /// <param name="pxHi">Hi pixel position in chart client rectangle coordinates</param>
        private void SetZoomAxisScale(Axis axis, int pxLow, int pxHi)
        {
            double minValue = Math.Max(axis.Minimum, axis.PixelPositionToValue(pxLow));
            double maxValue = Math.Min(axis.Maximum, axis.PixelPositionToValue(pxHi));
            double axisInterval = 0;
            double axisIntMinor = 0;
            if (useNiceRoundNumbers)
            {
                GetNiceRoundNumbers(ref minValue, ref maxValue, ref axisInterval, ref axisIntMinor);
            }
            else
                axisInterval = (maxValue - minValue) / 5d;

            axis.Minimum = minValue;
            axis.Maximum = maxValue;
            axis.Interval = axisInterval;
            axis.MinorTickMark.Interval = axisIntMinor;
            SetAxisFormats();
        }  /// <summary>
           /// Gets nice round numbers for the axes. For the horizontal axis, minValue is always 0.
           /// </summary>
           /// <param name="minValue"></param>
           /// <param name="maxValue"></param>
           /// <param name="axisInterval"></param>
        private void GetNiceRoundNumbers(ref double minValue, ref double maxValue, ref double interval, ref double intMinor)
        {
            double min = Math.Min(minValue, maxValue);
            double max = Math.Max(minValue, maxValue);
            double delta = max - min; //The full range
            //Special handling for zero full range
            if (delta == 0)
            {
                //When min == max == 0, choose arbitrary range of 0 - 1
                if (min == 0)
                {
                    minValue = 0;
                    maxValue = 1;
                    interval = 0.2;
                    intMinor = 0.5;
                    return;
                }
                //min == max, but not zero, so set one to zero
                if (min < 0)
                    max = 0; //min-max are -|min| to 0
                else
                    min = 0; //min-max are 0 to +|max|
                delta = max - min;
            }

            int N = Base10Exponent(delta);
            double tenToN = Math.Pow(10, N);
            double A = delta / tenToN;
            //At this point delta = A x Exp10(N), where
            // 1.0 <= A < 10.0 and N = integer exponent value
            //Now, based on A select a nice round interval and maximum value
            for (int i = 0; i < roundMantissa.Length; i++)
                if (A <= roundMantissa[i])
                {
                    interval = roundInterval[i] * tenToN;
                    intMinor = roundIntMinor[i] * tenToN;
                    break;
                }
            minValue = interval * Math.Floor(min / interval);
            maxValue = interval * Math.Ceiling(max / interval);
        }
        double[] roundMantissa = { 1.00d, 1.20d, 1.40d, 1.60d, 1.80d, 2.00d, 2.50d, 3.00d, 4.00d, 5.00d, 6.00d, 8.00d, 10.00d };
        double[] roundInterval = { 0.20d, 0.20d, 0.20d, 0.20d, 0.20d, 0.50d, 0.50d, 0.50d, 0.50d, 1.00d, 1.00d, 2.00d, 2.00d };
        double[] roundIntMinor = { 0.05d, 0.05d, 0.05d, 0.05d, 0.05d, 0.10d, 0.10d, 0.10d, 0.10d, 0.20d, 0.20d, 0.50d, 0.50d };
        bool axisFormatF0 = true;
        bool smartFormat = false;
        private void SetAxisFormats()
        {
            if (axisFormatF0)
            {
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "F0";
                chart1.ChartAreas[0].AxisY.LabelStyle.Format = "F0";
            }
            else if (smartFormat)
            {
                Axis axisX = chart1.ChartAreas[0].AxisX;
                axisX.LabelStyle.Format = RangeFormatString(axisX.Interval, axisX.Minimum, axisX.Maximum, 0);
                Axis axisY = chart1.ChartAreas[0].AxisY;
                axisY.LabelStyle.Format = RangeFormatString(axisY.Interval, axisY.Minimum, axisY.Maximum, 0);
            }
            else
            {
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "";
                chart1.ChartAreas[0].AxisY.LabelStyle.Format = "";
            }


        }  /// <summary>
           /// Returns a consistent format string with minimum necessary precision for a range with intervals
           /// </summary>
           /// <param name="interval">Range interval</param>
           /// <param name="minVal">Minimum value of the range</param>
           /// <param name="maxVal">Maximum value of the range</param>
           /// <param name="xtraDigits">Extra digits to display beyond those for minimum necessary precision</param>
           /// <returns></returns>
        public string RangeFormatString(double interval, double minVal, double maxVal, int xtraDigits)
        {
            double maxAbsVal = Math.Max(Math.Abs(minVal), Math.Abs(maxVal));
            int minE = Base10Exponent(interval); //precision to which must show decimal
            int maxE = Base10Exponent(maxAbsVal);
            //(maxE - minE + 1) is the number of significant 
            //digits needed to distinguish two numbers spaced by "interval"
            if (maxE < -4 || 3 < maxE)
                //"Exx" format displays 1 digit to the left of the decimal place, and xx
                //digits to the right of the decimal place, so xx = maxE - minE.
                return "E" + (xtraDigits + maxE - minE).ToString();
            else
                //In fixed format, since all digits to the left of the decimal place are
                //displayed by default, for "Fxx" format, xx = -minE or zero, whichever is greater.
                return "F" + xtraDigits + Math.Max(0, -minE).ToString();
        }

        //Base10Exponent returns the integer exponent (N) that would yield a
        //number of the form A x Exp10(N), where 1.0 <= |A| < 10.0
        public int Base10Exponent(double num)
        {
            if (num == 0)
                return -Int32.MaxValue;
            else
                return Convert.ToInt32(Math.Floor(Math.Log10(Math.Abs(num))));
        }
    }
    public static class GDI32
    {
        public enum DrawingMode
        {
            R2_NOTXORPEN = 10
        }

        [DllImport("gdi32.dll")]
        public static extern bool Rectangle(IntPtr hDC, int left, int top, int right, int bottom);

        [DllImport("gdi32.dll")]
        public static extern int SetROP2(IntPtr hDC, int fnDrawMode);

        [DllImport("gdi32.dll")]
        public static extern bool MoveToEx(IntPtr hDC, int x, int y, ref Point p);

        [DllImport("gdi32.dll")]
        public static extern bool LineTo(IntPtr hdc, int x, int y);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreatePen(int fnPenStyle, int nWidth, int crColor);

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObj);

        static private Point nullPoint = new Point(0, 0);

        // Convert the Argb from .NET to a gdi32 RGB
        static private int ArgbToRGB(int rgb)
        {
            return ((rgb >> 16 & 0x0000FF) | (rgb & 0x00FF00) | (rgb << 16 & 0xFF0000));
        }
        static public void DrawXORRectangle(Graphics graphics, Pen pen, Rectangle rectangle)
        {
            IntPtr hDC = graphics.GetHdc();
            IntPtr hPen = CreatePen((int)pen.DashStyle, (int)pen.Width, ArgbToRGB(pen.Color.ToArgb()));
            SelectObject(hDC, hPen);
            SetROP2(hDC, (int)DrawingMode.R2_NOTXORPEN);
            Rectangle(hDC, rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
            DeleteObject(hPen);
            graphics.ReleaseHdc(hDC);
        }

        static public void DrawXORLine(Graphics graphics, Pen pen, int x1, int y1, int x2, int y2)
        {
            IntPtr hDC = graphics.GetHdc();
            IntPtr hPen = CreatePen((int)pen.DashStyle, (int)pen.Width, ArgbToRGB(pen.Color.ToArgb()));
            SelectObject(hDC, hPen);
            SetROP2(hDC, (int)DrawingMode.R2_NOTXORPEN);
            MoveToEx(hDC, x1, y1, ref nullPoint);
            LineTo(hDC, x2, y2);
            DeleteObject(hPen);
            graphics.ReleaseHdc(hDC);
        }
    }

    /// <summary>
    /// Container class to maintain scaleing data for each chart's axes
    /// </summary>
    public class ChartScaleData
    {
        public Chart chart;
        public int chartIndex;
        public double xBaseMin, xBaseMax, xBaseInt, xBaseMinorInt;
        public double yBaseMin, yBaseMax, yBaseInt, yBaseMinorInt;
        public bool isZoomed = false;
        public bool scalesAreValid = false;  //only true after the chart has been drawn once;

        public ChartScaleData(Chart chart)
        {
            this.chart = chart;
        }

        public void UpdateAxisBaseDataX()
        {
            xBaseMinorInt = chart.ChartAreas[0].AxisX.MinorTickMark.Interval;
            xBaseInt = chart.ChartAreas[0].AxisX.Interval;
            xBaseMax = chart.ChartAreas[0].AxisX.Maximum;
            xBaseMin = chart.ChartAreas[0].AxisX.Minimum;
        }

        public void UpdateAxisBaseDataY()
        {
            yBaseMinorInt = chart.ChartAreas[0].AxisY.MinorTickMark.Interval;
            yBaseInt = chart.ChartAreas[0].AxisY.Interval;
            yBaseMax = chart.ChartAreas[0].AxisY.Maximum;
            yBaseMin = chart.ChartAreas[0].AxisY.Minimum;
        }

        public void UpdateAxisBaseData()
        {
            UpdateAxisBaseDataX();
            UpdateAxisBaseDataY();
        }

        public void ResetAxisScaleX()
        {
            chart.ChartAreas[0].AxisX.MinorTickMark.Interval = xBaseMinorInt;
            chart.ChartAreas[0].AxisX.Interval = xBaseInt;
            chart.ChartAreas[0].AxisX.Maximum = xBaseMax;
            chart.ChartAreas[0].AxisX.Minimum = xBaseMin;
        }

        public void ResetAxisScaleY()
        {
            chart.ChartAreas[0].AxisY.MinorTickMark.Interval = yBaseMinorInt;
            chart.ChartAreas[0].AxisY.Interval = yBaseInt;
            chart.ChartAreas[0].AxisY.Maximum = yBaseMax;
            chart.ChartAreas[0].AxisY.Minimum = yBaseMin;
        }

        public void ResetAxisScale()
        {
            ResetAxisScaleX();
            ResetAxisScaleY();
        }

        public RectangleF chartAreaRectangleF
        {
            get
            {
                Rectangle cr = chart.ClientRectangle;
                RectangleF rfp = chart.ChartAreas[0].Position.ToRectangleF();
                //rfp is the chart area rectangle as percentages of the entire chart ClientRectangle
                float chAreaX = rfp.Left * cr.Width / 100f;
                float chAreaY = rfp.Top * cr.Height / 100f;
                float chAreaW = rfp.Width * cr.Width / 100f;
                float chAreaH = rfp.Height * cr.Height / 100f;
                return new RectangleF(chAreaX, chAreaY, chAreaW, chAreaH);
            }
        }

        public Rectangle chartAreaRectangle { get { return Rectangle.Round(chartAreaRectangleF); } }

        public RectangleF innerPlotRectangleF
        {
            get
            {
                RectangleF rfi = chart.ChartAreas[0].InnerPlotPosition.ToRectangleF();
                //rfi is the inner plot area rectangle as percentages of the chart area rectangle 
                RectangleF chArea = chartAreaRectangleF;
                float ipX = chArea.X + rfi.Left * chArea.Width / 100f;
                float ipY = chArea.Y + rfi.Top * chArea.Height / 100f;
                float ipW = rfi.Width * chArea.Width / 100f;
                float ipH = rfi.Height * chArea.Height / 100f;
                return new RectangleF(ipX, ipY, ipW, ipH);
            }
        }

        public Rectangle innerPlotRectangle { get { return Rectangle.Round(innerPlotRectangleF); } }
    }
}
