using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingConsole.Shapes
{
    class ShapeWithManySide : Shape
    {
        public ShapeWithManySide()
        {
        }

        public ShapeWithManySide(bool fill, List<Point> points)
        {
            NameType = "ShapeWithManySide";
            Fill = fill;
            Points = points;
        }
        public override double Square
        {
            get
            {
                double sum   = 0;
                for (int i = 0; i < Points.Count; i++)
                {
                    if (i != Points.Count - 1)
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
                for(int i = 0; i < Points.Count; i++)
                {
                    if (i != Points.Count - 1)
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

        public override void Draw(int position)
        {
            DrawPicture.DrawShapeWithManySise(Points, position, Fill);
        }
    }
}
