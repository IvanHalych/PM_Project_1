using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingConsole.Shape
{
    class ShapeWithManySide : IShape
    {
        public ShapeWithManySide(Point[] points)
        {
            Points = points;
        }

        public Point[] Points{get;}
        public double Square
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

        public double Perimeter
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
