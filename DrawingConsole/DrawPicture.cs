using System;
using System.Collections.Generic;
using System.Linq;
using DrawingConsole.Exceptions;
using DrawingConsole.Shapes;
namespace DrawingConsole
{
    public static class DrawPicture
    {
        static readonly string MenuDrawInstruction = $"| {(char)0x2190}-left | {(char)0x2191}-up | {(char)0x2192}-right | {(char)0x2193}-down | Enter-enter | Backspase-back | Tab-Save |";

        public static Picture CreateShape<T>(Picture picture,bool fill, string Name) where T : Shape,new()
        {
            DrawingConsole.DrawMenu.PresentInstruction = MenuDrawInstruction;
            Drawing.ClearPicture();
            DrawShapes(picture.shapes);
            List<Point> points = new List<Point>();
            Console.SetCursorPosition(DrawMenu.LeftPicture, DrawMenu.TopPicture);
            Console.CursorVisible = true;
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                        if (points.Count != 0)
                        {
                            List<Point> list = new List<Point>(points)
                            {
                                new Point(GetPointX(), GetPointY())
                            };
                            List<Shape> listShapes = new List<Shape>(picture.shapes)
                            {
                                new T() { NameType = Name, Fill = fill, Points = list }
                            };
                            DrawShapes(listShapes);
                        }
                        else
                        {
                            DrawShapes(picture.shapes);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop != DrawMenu.TopPicture)
                        {
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                            if (points.Count != 0)
                            {
                                List<Point> list = new List<Point>(points)
                                {
                                    new Point(GetPointX(), GetPointY())
                                };
                                List<Shape> listShapes = new List<Shape>(picture.shapes)
                                {
                                    new T() { NameType = Name, Fill = fill, Points = list }
                                };
                                DrawShapes(listShapes);
                            }
                            else
                            {
                                DrawShapes(picture.shapes);
                            }
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Console.CursorLeft != DrawMenu.LeftPicture)
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            if (points.Count != 0)
                            {
                                List<Point> list = new List<Point>(points)
                                {
                                    new Point(GetPointX(), GetPointY())
                                };
                                List<Shape> listShapes = new List<Shape>(picture.shapes)
                                {
                                    new T() { NameType = Name, Fill = fill, Points = list }
                                };
                                DrawShapes(listShapes);
                            }
                            else
                            {
                                DrawShapes(picture.shapes);
                            }
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                        if (points.Count != 0)
                        {
                            List<Point> list = new List<Point>(points)
                            {
                                new Point(GetPointX(), GetPointY())
                            };
                            List<Shape> listShapes = new List<Shape>(picture.shapes)
                            {
                                new T() { NameType = Name, Fill = fill, Points = list }
                            };
                            DrawShapes(listShapes);
                        }
                        else
                        {
                            DrawShapes(picture.shapes);
                        }
                        break;
                    case ConsoleKey.Enter:
                        Point a = new Point(GetPointX(), GetPointY());
                        if(points.Count == 0)
                        {
                            points.Add(a);
                        } 
                        else if ((Name =="Line")&&(points.Count == 1)&&(!points[0].Equals(a))){
                            points.Add(a);
                            picture.shapes.Add(new Line(fill, points));
                            Console.CursorVisible = false;
                            return picture;
                        }
                        else if (points.All(p => !p.Equals(a)))
                            points.Add(a);
                        break;
                    case ConsoleKey.Tab:
                        List<Shape> listShapesDone = new List<Shape>(picture.shapes)
                        {
                            new T() { NameType = Name, Fill = fill, Points = points }
                        };
                        picture.shapes = listShapesDone;
                        Console.CursorVisible = false;
                        return picture;
                    case ConsoleKey.Escape:
                        throw new ExitException();
                    case ConsoleKey.Backspace:
                        Console.CursorVisible = false;
                        return picture;
                }
            }
        }
        public static void DrawLine(Point p1,Point p2, int position)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            if (p1.Equals(p2))
            {
                Console.SetCursorPosition(DrawMenu.LeftPicture + p1.X, DrawMenu.TopPicture + p1.Y);
                Console.Write(position);
            }
            else if (p1.X == p2.X)
            {
                if (p1.Y > p2.Y)
                {
                    Point a = p1;
                    p1 = p2;
                    p2 = a;
                }
                for (int y = p1.Y; y <= p2.Y; y++)
                {
                    Console.SetCursorPosition(DrawMenu.LeftPicture + p1.X, DrawMenu.TopPicture + y);
                    Console.Write(position);
                }
            }
            else if (p1.Y == p2.Y)
            {
                if (p1.X > p2.X)
                {
                    Point a = p1;
                    p1 = p2;
                    p2 = a;
                }
                for (int x = p1.X; x <= p2.X; x++)
                {
                    Console.SetCursorPosition(DrawMenu.LeftPicture + x, DrawMenu.TopPicture + p1.Y);
                    Console.Write(position);
                }
            }
            else
            {
                if (p1.X > p2.X)
                {
                    Point a = p1;
                    p1 = p2;
                    p2 = a;
                }
                for (int x = p1.X; x <= p2.X; x++)
                {
                    int y = (int)Math.Round(((double)(p2.Y - p1.Y)) * ((double)(x - p1.X)) / ((double)(p2.X - p1.X))) +p1.Y;
                    Console.SetCursorPosition(DrawMenu.LeftPicture + x, DrawMenu.TopPicture + y);
                    Console.Write(position);
                }
                if (p1.Y > p2.Y)
                {
                    Point a = p1;
                    p1 = p2;
                    p2 = a;
                }
                for (int y = p1.Y; y <= p2.Y; y++)
                {
                    int x = (int)Math.Round(((double)(p2.X - p1.X)) * ((double)(y - p1.Y)) / ((double)(p2.Y - p1.Y)))+ p1.X;
                    Console.SetCursorPosition(DrawMenu.LeftPicture + x, DrawMenu.TopPicture + y);
                    Console.Write(position);
                }
            }
            Console.SetCursorPosition(left,top);
        }
        public static void DrawCircle(Point p1,Point p2, int position, bool fill)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            double r = Point.Length(p1, p2);
            int leftSide = (int)Math.Round(p1.X - r);
            int rightSide = (int)Math.Round(p1.X + r);
            int upSide = (int)Math.Round(p1.Y - r);
            int downSide = (int)Math.Round(p1.Y + r);

            for (int i = upSide;i<=downSide;i++)
                for(int j = leftSide; j<= rightSide; j++)
                {
                    if (fill)
                    {
                        if (r >= Point.Length(p1, new Point(j, i)))
                        {
                            if (i >=0 && j >= 0) {
                                Console.SetCursorPosition(DrawMenu.LeftPicture + j, DrawMenu.TopPicture + i);
                                Console.Write(position);
                            }
                        }
                    }
                    else
                    {
                        if ((r >= Math.Round( Point.Length(p1, new Point(j, i))))&& (r - 1 < Math.Round(Point.Length(p1, new Point(j, i)))))
                        {
                            if (i >= 0 && j >= 0)
                            {
                                Console.SetCursorPosition(DrawMenu.LeftPicture + j, DrawMenu.TopPicture + i);
                                Console.Write(position);
                            }
                        }
                    }
                }
            Console.SetCursorPosition(left, top);
        }
        public static void DrawShapeWithManySise(List<Point> list, int position,bool fill)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            List<Point> listWritePoints = new List<Point>();
            for (int i=0;i< list.Count; i++)
            {
                if(i!= list.Count -1)
                {
                    listWritePoints = DrawLine(list[i], list[i + 1], position,listWritePoints);
                }
                else
                {
                    listWritePoints= DrawLine(list[i], list[0], position, listWritePoints);
                }
            }
            if (fill)
            {

                int leftSide = listWritePoints.Min(f => f.X);
                int rightSide = listWritePoints.Max(f => f.X);
                int upSide = listWritePoints.Min(f => f.Y);
                int downSide = listWritePoints.Max(f => f.Y);
                for (int i = upSide; i <= downSide; i++)
                    for (int j = leftSide; j <= rightSide; j++)
                    {
                        if (i - DrawMenu.TopPicture > 0 && j - DrawMenu.LeftPicture > 0)
                            if (listWritePoints.Any(f => f.X > j && f.Y == i))
                                if (listWritePoints.Any(f => f.X < j && f.Y == i))
                                    if (listWritePoints.Any(f => f.Y > i && f.X == j))
                                        if (listWritePoints.Any(f => f.Y < i && f.X == j))
                                        {
                                            Console.SetCursorPosition(j,i);
                                            Console.Write(position);
                                        }
                    }
            }          
            Console.SetCursorPosition(left, top);
        }
        public static List<Point> DrawLine(Point p1, Point p2, int position,List<Point> points)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            if (p1.Equals(p2))
            {
                Console.SetCursorPosition(DrawMenu.LeftPicture + p1.X, DrawMenu.TopPicture + p1.Y);
                points.Add(new Point(DrawMenu.LeftPicture + p1.X, DrawMenu.TopPicture + p1.Y));
                Console.Write(position);
            }
            else if (p1.X == p2.X)
            {
                if (p1.Y > p2.Y)
                {
                    Point a = p1;
                    p1 = p2;
                    p2 = a;
                }
                for (int y = p1.Y; y <= p2.Y; y++)
                {
                    Console.SetCursorPosition(DrawMenu.LeftPicture + p1.X, DrawMenu.TopPicture + y);
                    points.Add(new Point(DrawMenu.LeftPicture + p1.X, DrawMenu.TopPicture + y));
                    Console.Write(position);
                }
            }
            else if (p1.Y == p2.Y)
            {
                if (p1.X > p2.X)
                {
                    Point a = p1;
                    p1 = p2;
                    p2 = a;
                }
                for (int x = p1.X; x <= p2.X; x++)
                {
                    Console.SetCursorPosition(DrawMenu.LeftPicture + x, DrawMenu.TopPicture + p1.Y);
                    points.Add(new Point(DrawMenu.LeftPicture + x, DrawMenu.TopPicture + p1.Y));
                    Console.Write(position);
                }
            }
            else
            {
                if (p1.X > p2.X)
                {
                    Point a = p1;
                    p1 = p2;
                    p2 = a;
                }
                for (int x = p1.X; x <= p2.X; x++)
                {
                    int y = (int)Math.Round(((double)(p2.Y - p1.Y)) * ((double)(x - p1.X)) / ((double)(p2.X - p1.X))) + p1.Y;
                    Console.SetCursorPosition(DrawMenu.LeftPicture + x, DrawMenu.TopPicture + y);
                    points.Add(new Point(DrawMenu.LeftPicture + x, DrawMenu.TopPicture + y));
                    Console.Write(position);
                }
                if (p1.Y > p2.Y)
                {
                    Point a = p1;
                    p1 = p2;
                    p2 = a;
                }
                for (int y = p1.Y; y <= p2.Y; y++)
                {
                    int x = (int)Math.Round(((double)(p2.X - p1.X)) * ((double)(y - p1.Y)) / ((double)(p2.Y - p1.Y))) + p1.X;
                    Console.SetCursorPosition(DrawMenu.LeftPicture + x, DrawMenu.TopPicture + y);
                    points.Add(new Point(DrawMenu.LeftPicture + x, DrawMenu.TopPicture + y));
                    Console.Write(position);
                }
            }
            Console.SetCursorPosition(left, top);
            return points;
        }
        public static void DrawShapes(List<Shape> shapes)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Drawing.ClearPicture();
            for( int i = 0; i < shapes.Count; i++)
            {
                shapes[i].Draw(shapes.Count - 1 - i);
            }
            Console.SetCursorPosition(left, top);
        }
        public static int GetPointX()
        {
            return Console.CursorLeft - DrawMenu.LeftPicture;
        }
        public static int GetPointY()
        {
            return Console.CursorTop - DrawMenu.TopPicture;
        }
    }
}
