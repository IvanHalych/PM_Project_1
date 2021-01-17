using System;
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
                            DrawLine(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture), 0);
                        break;
                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop != DrawMenu.TopPicture)
                        {
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                            if (a != null)
                                DrawLine(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture), 0);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Console.CursorLeft != DrawMenu.LeftPicture)
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            if (a != null)
                                DrawLine(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture), 0);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                        if (a != null)
                            DrawLine(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture), 0);
                        break;
                    case ConsoleKey.Enter:
                        if (a==null)
                        {
                            a = new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture);
                        }
                        else
                        {
                            return new Line(a, new Point(Console.CursorLeft - DrawMenu.LeftPicture, Console.CursorTop - DrawMenu.TopPicture), 0);
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
            DrawingConsole.Program.ClearPicture();
            if (p1.Equals(p2))
            {
                Console.SetCursorPosition(DrawMenu.LeftPicture + p1.X, DrawMenu.TopPicture + p1.Y);
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
    }
}
