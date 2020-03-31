using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019Day3
{
    struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
    class Program
    {
        private const int SIZE = 1000;

        static void Main(string[] args)
        {
            int[,] grid = new int[SIZE, SIZE];
            Point origin = new Point(8, 1);
            DrawWires(ref grid, in origin);
            Console.WriteLine($"Part 1: distance = {FindShortestIntersection(ref grid)}");
        }

        static int FindShortestIntersection(ref int[,] grid)
        {
            throw new NotImplementedException();
        }

        static void DrawWires(ref int[,] grid, in Point origin)
        {
            // Mark the central port with a -1
            grid[origin.X, origin.Y] = -1;
            Point currentLocation = new Point(origin.X, origin.Y);
            // Read in the input
            var wires = new List<List<string>>();
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    wires.Add(line.Split(',').ToList());
                }
            }
            // mark the first wire's position with 1's
            int wireNum = 1;
            foreach (var wire in wires)
            {
                foreach (var path in wire)
                {
                    ParsePath(ref grid, ref currentLocation, wireNum, path);
                }
            }
        }

        static void ParsePath(ref int[,] grid, ref Point currentLocation, int wireNum, string path)
        {
            char direction = path[0];
            if (Int32.TryParse(path.Substring(1), out int distance))
            {
                switch (direction)
                {
                    case 'U':
                        // Y += distance
                        break;
                    case 'D':
                        // Y -= distance
                        break;
                    case 'R':
                        // X += distance
                        break;
                    case 'L':
                        // X -= distance
                        break;
                    default:
                        throw new ArgumentException($"Invalid direction {direction} in input");
                }
            }
            else
            {
                throw new ArgumentException("Invalid distance specified in input");
            }
        }
    }
}
