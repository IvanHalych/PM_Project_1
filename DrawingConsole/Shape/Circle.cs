using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingConsole.Shape
{
    class Circle : IShape
    {
        public Circle()
        {
        }

        public Circle(Point x, double r)
        {
            X = x;
            R = r;
        }

        public Point X { get; }
        public double R { get; }
        public double Square
        {
            get { return Math.PI * Math.PI * R;  }
        }

        public double Perimeter
        {
            get { return 2 * Math.PI * R; }
        }
    }
}
