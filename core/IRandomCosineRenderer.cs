using System.Collections.Generic;

namespace DoubleSplit.Core
{
    public interface IRandomCosinePlaneRenderer
    {
        double GetProbabilityForPoint(Point point);

        Dictionary<Point, double> GetProbabilityForPlane();
    }
}