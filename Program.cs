using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using alg.core;

namespace alg
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var planeValidator = new PlaneValidator();
            var planeSize = new PlaneSize(1500, 500);
            var plane = new Plane(planeValidator, planeSize, 4);

            var renderer = new RandomCosinePlaneRenderer(plane);

            var probabilityForPlane = renderer.GetProbabilityForPlane();
            var sum = probabilityForPlane.Values.Sum();
            var max = probabilityForPlane.Max(e => e.Value);
            var min = probabilityForPlane.Min(e => e.Value);

            Console.WriteLine($"Sum of the probability of all points is {sum}");
            Console.WriteLine($"The maximum probability is {max}");
            Console.WriteLine($"The minimum probability is {min}");

            var scaledProbabilities = new Dictionary<double, Point>();

            double index = 0;
            foreach (var (point, probability) in probabilityForPlane)
            {
                if(Math.Abs(probability) <= 0)
                    continue;
                
                index = index + probability;
                scaledProbabilities.Add(index, point);
            }

            var random = new Random();
            var hitList = new Point[10000];

            Console.WriteLine("Start creating hit list...");

            for (var i = 0; i < 10000; i++)
            {
                var nextRandomValue = random.NextDouble();
                var nextRandomPoint = scaledProbabilities.First(e => e.Key >= nextRandomValue).Value;
                hitList[i] = nextRandomPoint;
            }

            Console.WriteLine("Created hit list...");

            var csv = new StringBuilder();
            csv.AppendLine("X,Y");

            foreach (var hitPoint in hitList)
            {
                Console.WriteLine($"Adding hit point ({hitPoint.X}, {hitPoint.Y})...");
                csv.AppendLine($"{hitPoint.X}, {hitPoint.Y}");
            }
            
            Console.WriteLine("Writing hit list...");

            File.WriteAllText("./hitlist2.csv", csv.ToString());

            Console.WriteLine("Finished...");
        }
    }
}
