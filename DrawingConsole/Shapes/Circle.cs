using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingConsole.Shapes
{
    public class Circle : Shape
    {
        public Circle()
        {
        }

        public Circle(bool fill, List<Point> points)
        {
            NameType = "Circle";
            Fill = fill;
            Points = points;
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

        public override void Draw(int position)
        {
            DrawPicture.DrawCircle(Points[0], Points[1], position, Fill);
        }
    }
}
