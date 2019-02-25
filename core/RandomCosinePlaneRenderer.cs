using System;
using System.Collections.Generic;

namespace alg.core
{
    public class RandomCosinePlaneRenderer : IRandomCosinePlaneRenderer
    {
        private readonly int _probabilityPerPixel;
        private readonly double _planeToIterationRatio;
        private readonly PlaneSize _planeSize;

        public RandomCosinePlaneRenderer(Plane plane)
        {
            _planeSize = plane.Size;

            _probabilityPerPixel = _planeSize.X * _planeSize.Y;

            _planeToIterationRatio = (plane.NumberOfCosineIterations * System.Math.PI) / _planeSize.X;
        }
        
        public double GetProbabilityForPoint(Point point)
        {
            var xCoordinateToRatio = _planeToIterationRatio * point.X;

            return (System.Math.Cos(xCoordinateToRatio) + 1) / _probabilityPerPixel;
        }

        public Dictionary<Point, double> GetProbabilityForPlane()
        {
            var dict = new Dictionary<Point, double>();

            for (var x = 0; x <= _planeSize.X; x++)
            {
                for (var y = 0; y <= _planeSize.Y; y++)
                {
                    var point = new Point(x, y);
                    var probability = GetProbabilityForPoint(point);
                    
                    //Console.WriteLine($"Adding point ({point.X}, {point.Y}) with a probability of {probability} to the dictionary...");
                    
                    dict.Add(point, probability);
                }                
            }

            return dict;
        }
    }
}