using System;
using System.Collections.Generic;

namespace AdventOfCode2019Day3
{
    class Program
    {
        private const int SIZE = 1000;

        static void Main(string[] args)
        {
            int[,] grid = new int[SIZE,SIZE];
            DrawWires(ref grid);
            Console.WriteLine($"Part 1: distance = {FindShortestIntersection(ref grid)}");
        }

        static int FindShortestIntersection(ref int[,] grid)
        {
            throw new NotImplementedException();
        }

        static void DrawWires(ref int[,] grid)
        {
            throw new NotImplementedException();
        }

        
    }
}
