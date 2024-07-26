using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PNB.GUI.GUIHelper
{
    public partial class ucChart3 : UserControl
    {
        VLine vl;
        HLine hl;
        public ScottPlot.FormsPlot Plot1;
        public ucChart3()
        {
            InitializeComponent();

            Plot1 = this.formsPlot1;
            
            //this.formsPlot1.MouseMoved += new System.Windows.Forms.MouseEventHandler(this.formsPlot1_MouseMoved);

            checkedListBox1.ItemCheck += delegate (object sender, ItemCheckEventArgs e)
            {
                SignalPlot sp1 = checkedListBox1.Items[e.Index] as SignalPlot;
                sp1.IsVisible = e.NewValue == CheckState.Checked;
                formsPlot1.Render();
            };
        }

        public void AddPoints(string title, string[] yLable, string xLable, double[][] ys)
        {
            Invoke((MethodInvoker)delegate
            {
                ///Clear Menu
                checkedListBox1.Items.Clear();
                var plt = new Plot();
                //var plt = Plot1.plt;
               
                
                //vl = plt.AddVerticalLine(0, Color.Red, 1, LineStyle.Dash, null);
                //hl = plt.AddHorizontalLine(0, Color.Red, 1, LineStyle.Dash, null);
                vl = plt.PlotVLine(0, color: Color.Red, lineStyle: LineStyle.Dash);
                hl = plt.PlotHLine(0, color: Color.Red, lineStyle: LineStyle.Dash);

                plt.Title(title);
                plt.XLabel(xLable);

                for (int i = 0; i < ys.GetLength(0); i++)
                {
                    double[] y = ys[i];
                    SignalPlot sp = plt.AddSignal(y);
                    sp.Name = yLable[i];

                    if (i > 1)
                    {
                        var yAxis3 = plt.AddAxis(ScottPlot.Renderable.Edge.Left, i + 2);
                        yAxis3.Label(yLable[i]);
                    }
                    else
                        plt.YAxis.Label(yLable[i]);
                    int index = checkedListBox1.Items.Add(sp);
                    checkedListBox1.SetItemChecked(index, true);
                }
                Plot1.Reset(plt);
                Plot1.Render();
            });
        }

        private void formsPlot1_MouseMoved(object sender, MouseEventArgs e)
        {
            (double coordinateX, double coordinateY) = formsPlot1.GetMouseCoordinates();

            if (vl != null)
            {
                vl.X = coordinateX;
                hl.Y = coordinateY;

                formsPlot1.Render(skipIfCurrentlyRendering: true);
            }
        }
    }
}
