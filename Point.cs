using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode2019Day3
{
    public class Point : IEquatable<Point>
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(Point other)
        {
            if (other == null)
                return false;

            if (this.X == other.X && this.Y == other.Y)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Point point = obj as Point;
            if (point == null)
                return false;
            else
                return Equals(point);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Point point1, Point point2)
        {
            if (((object)point1) == null || (object)point2 == null)
                return Object.Equals(point1, point2);

            return point1.Equals(point2);
        }

        public static bool operator !=(Point point1, Point point2)
        {
            if (((object)point1) == null || (object)point2 == null)
                return !Object.Equals(point1, point2);

            return !(point1.Equals(point2));
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
