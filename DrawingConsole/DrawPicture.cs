using System;
using System.Collections.Generic;
using System.Linq;
using DrawingConsole.Shapes;
namespace DrawingConsole
{
    public static class DrawPicture
    {
        public static Line  CreateLine()
        {
            Point a =null;
            Console.SetCursorPosition(DrawMenu.LeftPicture, DrawMenu.TopPicture);
            Console.CursorVisible = true;
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(Console.CursorLeft,Console.CursorTop + 1);
                        if (a != null)
                            DrawLine(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture),0);
                        break;
                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop != DrawMenu.TopPicture)
                        {
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                            if (a != null)
                                DrawLine(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture),0);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Console.CursorLeft != DrawMenu.LeftPicture)
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            if (a != null)
                                DrawLine(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture),0);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                        if (a != null)
                            DrawLine(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture),0);
                        break;
                    case ConsoleKey.Enter:
                        if (a==null)
                        {
                            a = new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture);
                        }
                        else
                        {
                            return new Line(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture));
                        }
                        break;
                    case ConsoleKey.Escape:
                        return null;
                    case ConsoleKey.Backspace:
                        return null;
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

        internal static Circle CreateCircle(bool fill)
        {
            Point a = null;
            Console.SetCursorPosition(DrawMenu.LeftPicture, DrawMenu.TopPicture);
            Console.CursorVisible = true;
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                        if (a != null)
                            DrawCircle(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture), 0,fill);
                        break;
                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop != DrawMenu.TopPicture)
                        {
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                            if (a != null)
                                DrawCircle(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture), 0,fill);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Console.CursorLeft != DrawMenu.LeftPicture)
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            if (a != null)
                                DrawCircle(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture), 0,fill);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                        if (a != null)
                            DrawCircle(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture),0,fill);
                        break;
                    case ConsoleKey.Enter:
                        if (a == null)
                        {
                            a = new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture);
                        }
                        else
                        {
                            return new Circle(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture),fill);
                        }
                        break;
                    case ConsoleKey.Escape:
                        return null;
                    case ConsoleKey.Backspace:
                        return null;
                }
            }
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
        internal static ShapeWithManySide CreateShapeWithManySide(bool fill)
        {
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
                            List<Point> list = new List<Point>(points);
                            list.Add(new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture));
                            DrawingConsole.Program.ClearPicture();
                            DrawShapeWithManySise(list, 0, fill);
                        }

                        break;
                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop != DrawMenu.TopPicture)
                        {
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                            if (points.Count != 0)
                            {
                                List<Point> list = new List<Point>(points);
                                list.Add(new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture));
                                DrawingConsole.Program.ClearPicture();
                                DrawShapeWithManySise(list, 0, fill);
                            }
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Console.CursorLeft != DrawMenu.LeftPicture)
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            if (points.Count != 0)
                            {
                                List<Point> list = new List<Point>(points);
                                list.Add(new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture));
                                DrawingConsole.Program.ClearPicture();
                                DrawShapeWithManySise(list, 0, fill);
                            }
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                        if (points.Count != 0)
                        {
                            List<Point> list = new List<Point>(points);
                            list.Add(new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture));
                            DrawingConsole.Program.ClearPicture();
                            DrawShapeWithManySise(list, 0, fill);
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (points.Count!=0&&points[0].Equals(new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture)))
                            return new ShapeWithManySide(points.ToArray(), fill);
                        points.Add(new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture));
                        break;
                    case ConsoleKey.Escape:
                        return null;
                    case ConsoleKey.Backspace:
                        return null;

                }
            }
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
    }
}
