using System;

namespace MazeSolver.Data
{
    public class Point
    {
        public int X { set; get; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("Point({0}, {1})", X, Y);
        }
    }
}