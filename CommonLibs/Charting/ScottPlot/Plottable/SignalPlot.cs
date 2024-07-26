using ScottPlot.MinMaxSearchStrategies;

namespace ScottPlot.Plottable
{
    public class SignalPlot : SignalPlotBase<double>
    {
        public string Name { set; get; }
        public SignalPlot() : base()
        {
            Strategy = new LinearDoubleOnlyMinMaxStrategy();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
