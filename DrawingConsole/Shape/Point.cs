using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingConsole.Shape
{
    public class Point : IShape
    {
        public int X;
        public int Y;

        public Point()
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public double Square { get { return 0; } }

        public double Perimeter { get { return 0; } }

        public static double Length(Point A,Point B)
        {
            return Math.Sqrt(Math.Pow(A.X-B.X,2)+Math.Pow(A.Y-B.Y,2));
        }
    }
}
