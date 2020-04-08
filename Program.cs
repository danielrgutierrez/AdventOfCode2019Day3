using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Wire = System.Collections.Generic.List<AdventOfCode2019Day3.Point>;

namespace AdventOfCode2019Day3
{

    class Program
    {
        static void Main(string[] args)
        {
            var wirePaths = new List<List<string>>();
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    wirePaths.Add(line.Split(',').ToList());
                }
            }

            Point origin = new Point(0, 0);
            var wires = new List<Wire>();

            foreach (var wirePath in wirePaths)
            {
                var wire = new Wire();
                wire.Add(origin);
                foreach (var directive in wirePath)
                {
                    char direction = directive[0];
                    if (Int32.TryParse(directive.Substring(1), out int distance))
                    {
                        Point currentPoint = wire[wire.Count - 1];
                        foreach (var point in new PointSequence(currentPoint, direction, distance))
                        {
                            wire.Add(point);
                        }

                    }
                    else
                    {
                        throw new ArgumentException("Invalid distance specified in input");
                    }
                }
                wires.Add(wire);
            }
            Console.WriteLine($"Part 1: distance = {FindShortestIntersection(in wires, origin)}");
        }

        static int FindShortestIntersection(in List<Wire> wires, Point origin)
        {
            var intersections = wires.Aggregate((previousWire, nextWire) => previousWire.Intersect(nextWire).ToList());
            intersections.Remove(origin);
            return intersections.Select(intersection => CalcTaxiCabDistance(origin, intersection)).Min();
        }

        static int CalcTaxiCabDistance(in Point point1, in Point point2)
        {
            return Math.Abs(point1.X - point2.X) + Math.Abs(point1.Y - point2.Y);
        }
    }
}
