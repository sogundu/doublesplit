using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DoubleSplit.Core;
using RangeTree;

namespace DoubleSplit
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var tree = CreateTree();

            var random = new Random();
            var hitList = new Point[10000];

            Console.WriteLine("Start creating hit list...");

            for (var i = 0; i < 10000; i++)
            {
                var nextRandomValue = random.NextDouble();
                var nextRandomPoint = tree.Query(nextRandomValue).Single().Point;
                hitList[i] = nextRandomPoint;
            }

            Console.WriteLine("Created hit list...");

            CreateCSV(hitList);
        }

        private static RangeTree<double, ProbabilityRangeItem> CreateTree()
        {
            var tree = new RangeTree<double, ProbabilityRangeItem>(new ProbabilityRangeItemComparer());

            var planeValidator = new PlaneValidator();
            var planeSize = new PlaneSize(1500, 500);
            var plane = new Plane(planeValidator, planeSize, 8);
            var renderer = new RandomCosinePlaneRenderer(plane);
            var probabilityForPlane = renderer.GetProbabilityForPlane();

            double index = 0;
            foreach (var (point, probability) in probabilityForPlane)
            {
                if (Math.Abs(probability) <= 0)
                    continue;

                tree.Add(new ProbabilityRangeItem(new Range<double>(index, index + probability), point));
                index += probability;
            }

            return tree;
        }

        private static void CreateCSV(Point[] hitList)
        {
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