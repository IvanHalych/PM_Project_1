using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingConsole.Shapes
{
    public class Line : Shape
    {
        public Line()
        { }
        public Line(bool fill , List<Point> points)
        {
            Fill = fill;
            Points = points;
            NameType = "Line";
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

        public override void Draw(int position)
        {
            DrawPicture.DrawLine(A,B,position);
        }
    }
}
