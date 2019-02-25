using System.Collections.Generic;

namespace alg.core
{
    public interface IRandomCosinePlaneRenderer
    {
        double GetProbabilityForPoint(Point point);

        Dictionary<Point, double> GetProbabilityForPlane();
    }
}