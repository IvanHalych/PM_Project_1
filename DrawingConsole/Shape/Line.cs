using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingConsole.Shape
{
    class Line : IShape
    {
        public Line()
        {
        }

        public Line(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public Point A { get; }
        public Point B { get; }
        public double Square { get { return 0; } }

        public double Perimeter { get { return 0; } }
    }
}
