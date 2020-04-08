using System;
using System.Collections;
using System.Collections.Generic;
using static System.Linq.Enumerable; // for Enumerable.Range

namespace AdventOfCode2019Day3
{
    public class PointSequence : IEnumerable
    {
        public Point StartingPoint { get; private set; }
        public int Distance { get; private set; }
        public char Direction { get; private set; }

        public PointSequence(Point startingPoint, char direction, int distance)
        {
            this.StartingPoint = new Point(startingPoint.X, startingPoint.Y);
            this.Direction = direction;
            this.Distance = distance;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public PointSequenceEnum GetEnumerator()
        {
            return new PointSequenceEnum(StartingPoint, Direction, Distance);
        }
    }

    public class PointSequenceEnum : IEnumerator
    {
        private List<Point> _points;
        int position = -1;

        public PointSequenceEnum(Point startingPoint, char direction, int distance)
        {
            _points = new List<Point>();

            switch (direction)
            {
                case 'U':
                    foreach (var y in Range(startingPoint.Y + 1, distance))
                    {
                        _points.Add(new Point(startingPoint.X, y));
                    }
                    break;
                case 'D':
                    foreach (var y in Range(1, distance))
                    {
                        int newY = startingPoint.Y - y;
                        _points.Add(new Point(startingPoint.X, newY));
                    }
                    break;
                case 'R':
                    foreach (var x in Range(startingPoint.X + 1, distance))
                    {
                        _points.Add(new Point(x, startingPoint.Y));
                    }
                    break;
                case 'L':
                    foreach (var x in Range(1, distance))
                    {
                        int newX = startingPoint.X - x;
                        _points.Add(new Point(newX, startingPoint.Y));
                    }
                    break;
                default:
                    throw new ArgumentException($"Invalid direction {direction} in input");
            }
        }

        public bool MoveNext()
        {
            position++;
            return (position < _points.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Point Current
        {
            get
            {
                try
                {
                    return _points[position];
                }
                catch (IndexOutOfRangeException e)
                {
                    throw e;
                }
            }
        }
    }
}


