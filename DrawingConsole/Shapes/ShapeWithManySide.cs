using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingConsole.Shapes
{
    class ShapeWithManySide : Shape
    {
        public bool Fill { get; set; }
        public ShapeWithManySide(Point[] points,bool fill)
        {
            Fill = fill;
            Points = points;
        }
        public override double Square
        {
            get
            {
                double sum   = 0;
                for (int i = 0; i < Points.Length; i++)
                {
                    if (i != Points.Length - 1)
                    {
                        sum += (Points[i].X * Points[i + 1].Y -Points[i].Y*Points[i+1].X);
                    }
                    else
                    {
                        sum += (Points[i].X * Points[0].Y - Points[i].Y * Points[0].X);
                    }
                }
                return sum / 2; ;
            }
        }

        public override double Perimeter
        {
            get
            {
                double perimeter = 0;
                for(int i = 0; i < Points.Length; i++)
                {
                    if (i != Points.Length - 1)
                    {
                        perimeter += Point.Length(Points[i], Points[i + 1]);
                    }
                    else
                    {
                        perimeter += Point.Length(Points[i], Points[0]);
                    }
                }
                return perimeter;
            }
        }
    }
}
