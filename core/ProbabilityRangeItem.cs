using RangeTree;

namespace DoubleSplit.Core
{
    public class ProbabilityRangeItem : IRangeProvider<double>
    {
        public Range<double> Range { get; }

        public Point Point { get; }

        public ProbabilityRangeItem(Range<double> range, Point point)
        {
            Range = range;
            Point = point;
        }
    }
}