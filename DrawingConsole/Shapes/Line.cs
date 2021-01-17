using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingConsole.Shapes
{
    public class Line : Shape
    {

        public Line(Point a, Point b,int position)
        {
            NameType = "Line";
            Points = new Point[] { a, b };
        }

        public Point A
        {
            get
            {
                return Points[0];
            }
        }
        public Point B
        {
            get
            {
                return Points[1];
            }
        }
        public override double Square { get { return 0; } }

        public override double Perimeter { get { return 0; } }
    }
}
