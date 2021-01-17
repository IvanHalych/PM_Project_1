using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingConsole.Shapes
{
    class Circle : Shape
    {

        public Circle(Point x, Point y, int position)
        {
            NameType = "Circle";
            Points = new Point[] { x, y };
        }

        public Point X
        {
            get
            {
                return Points[0];
            }
        }
        public double R
        {
            get
            {
                return Point.Length( Points[0], Points[1]);
            }
        }
        public override double Square
        {
            get { return  Math.Pow(Math.PI,2)* R;  }
        }

        public override double Perimeter
        {
            get { return 2 * Math.PI * R; }
        }
    }
}
