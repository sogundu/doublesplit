using System.Collections.Generic;

namespace DoubleSplit.Core
{
    public class ProbabilityRangeItemComparer : IComparer<ProbabilityRangeItem>
    {
        public int Compare(ProbabilityRangeItem x, ProbabilityRangeItem y)
        {
            return x.Range.CompareTo(y.Range);
        }
    }
}