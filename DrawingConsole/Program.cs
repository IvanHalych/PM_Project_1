using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace DrawingConsole
{
    class Program
    {
        static string[] headMenu = new string[] { "File", "Draw" };
        static string[] fileMenu = new string[] { "NewFile", "Open","Save" };
        static string[] drawMenu = new string[] { "NewDraw", "Change", "Delete" };
        static string[] newDrawMenu = new string[] { "Line", "Circle", "Shape With Many Side" };
        static Dictionary<string, Action> pairs = new Dictionary<string, Action>();
        static Stack<string[]> StackMenu = new Stack<string[]>();
        static Picture picture;
        static void Main()
        {
            Console.CursorVisible = false;
            Console.ResetColor();
            pairs.Add("File", FileMenu);
            pairs.Add("Draw", DrawMenu);
            pairs.Add("NewDraw", NewDrawMenu);
            pairs.Add("Line", CreateLine);
            pairs.Add("Circle", CreateCircle);
            pairs.Add("Shape With Many Side", CreateShape);
            pairs.Add("NewFile", NewFile);
            pairs.Add("Save", Save);
            pairs.Add("Open", Open);
            DrawingConsole.DrawMenu.DrawMenuInstruction();
            DrawingConsole.DrawMenu.DoDrawMenu(headMenu);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if(DrawingConsole.DrawMenu.PositionMenu != DrawingConsole.DrawMenu.PresentMenu.Length-1)
                        {
                            DrawingConsole.DrawMenu.PositionMenu++;
                            DrawingConsole.DrawMenu.DrawMenuItemSelect();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (DrawingConsole.DrawMenu.PositionMenu != 0&& DrawingConsole.DrawMenu.PositionMenu!=-1)
                        {
                            DrawingConsole.DrawMenu.PositionMenu--;
                            DrawingConsole.DrawMenu.DrawMenuItemSelect();
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (DrawingConsole.DrawMenu.PositionMenu != -1)
                        {
                            pairs.GetValueOrDefault(DrawingConsole.DrawMenu.PresentMenu[DrawingConsole.DrawMenu.PositionMenu]).Invoke();
                        }
                        break;
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Backspace:
                        BackSpaceMenu();
                        break;
                }
            }
        }

        private static void CreateShape()
        {
            while (true)
            {
                Console.Clear();
                DrawingConsole.DrawMenu.DrawMenuInstruction();
                DrawingConsole.DrawMenu.DoDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
                Console.SetCursorPosition(DrawingConsole.DrawMenu.LeftPicture, DrawingConsole.DrawMenu.TopPicture);
                Console.Write("How draw Shape(fill/empty): ");
                Console.CursorVisible = true;
                string input = Console.ReadLine();
                if (input == "fill")
                {
                    Console.Clear();
                    DrawingConsole.DrawMenu.DrawMenuInstruction();
                    DrawingConsole.DrawMenu.DoDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
                    picture.shapes.Add(DrawPicture.CreateShapeWithManySide(true));
                    Console.CursorVisible = false;
                    break;
                }
                else if (input == "empty")
                {
                    Console.Clear();
                    DrawingConsole.DrawMenu.DrawMenuInstruction();
                    DrawingConsole.DrawMenu.DoDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
                    picture.shapes.Add(DrawPicture.CreateShapeWithManySide(false));
                    Console.CursorVisible = false;
                    break;
                }
                else
                {
                    Console.CursorLeft = DrawingConsole.DrawMenu.LeftPicture;
                    Console.Write("Error input");
                    Console.ReadKey();
                }
            }
        }

        private static void CreateCircle()
        {
            while (true)
            {
                Console.Clear();
                DrawingConsole.DrawMenu.DrawMenuInstruction();
                DrawingConsole.DrawMenu.DoDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
                Console.SetCursorPosition(DrawingConsole.DrawMenu.LeftPicture, DrawingConsole.DrawMenu.TopPicture);
                Console.Write("How draw Circle(fill/empty): ");
                Console.CursorVisible = true;
                string input = Console.ReadLine();
                if (input =="fill")
                {
                    Console.Clear();
                    DrawingConsole.DrawMenu.DrawMenuInstruction();
                    DrawingConsole.DrawMenu.DoDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
                    picture.shapes.Add(DrawPicture.CreateCircle(true));
                    Console.CursorVisible = false;
                    break;
                }
                else if (input == "empty")
                {
                    Console.Clear();
                    DrawingConsole.DrawMenu.DrawMenuInstruction();
                    DrawingConsole.DrawMenu.DoDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
                    picture.shapes.Add(DrawPicture.CreateCircle(false));
                    Console.CursorVisible = false;
                    break;
                }
                else
                {
                    Console.CursorLeft = DrawingConsole.DrawMenu.LeftPicture;
                    Console.Write("Error input");
                    Console.ReadKey();
                }
            }
        }

        private static void Open()
        {
            while (true)
            {
                Console.Clear();
                DrawingConsole.DrawMenu.DrawMenuInstruction();
                DrawingConsole.DrawMenu.DoDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
                Console.SetCursorPosition(DrawingConsole.DrawMenu.LeftPicture, DrawingConsole.DrawMenu.TopPicture);
                Console.Write("Enter name  open file(A-Z,a-z,_): ");
                string intput = Console.ReadLine();
                Regex regex = new Regex(@"[A-Z||a-z||_]+");
                if (regex.IsMatch(intput))
                {
                    Console.CursorLeft = DrawingConsole.DrawMenu.LeftPicture;
                    try
                    {
                        picture = FileWork.Read(intput);
                        Console.Write("File open");
                    }
                    catch(FileNotFoundException)
                    {
                        Console.Write("File Not Found");
                    }
                    break;
                }
                else
                {
                    Console.CursorLeft = DrawingConsole.DrawMenu.LeftPicture;
                    Console.Write("Error input");
                }
            }
        }

        private static void Save()
        {
            FileWork.Save(picture);
        }

        private static void CreateLine()
        {
            picture.shapes.Add(DrawPicture.CreateLine());
            BackSpaceMenu();
        }

        private static void BackSpaceMenu()
        {
            Console.Clear();
            DrawingConsole.DrawMenu.DrawMenuInstruction();
            DrawingConsole.DrawMenu.DoDrawMenu(StackMenu.Pop());
        }

        static void FileMenu()
        {
            StackMenu.Push(DrawingConsole.DrawMenu.PresentMenu);
            Console.Clear();
            DrawingConsole.DrawMenu.DrawMenuInstruction();
            DrawingConsole.DrawMenu.DoDrawMenu(fileMenu);
        }
        static void DrawMenu()
        {
            StackMenu.Push(DrawingConsole.DrawMenu.PresentMenu);
            Console.Clear();
            DrawingConsole.DrawMenu.DrawMenuInstruction();
            DrawingConsole.DrawMenu.DoDrawMenu(drawMenu);
        }
        static void NewDrawMenu()
        {
            
            StackMenu.Push(DrawingConsole.DrawMenu.PresentMenu);
            Console.Clear();
            DrawingConsole.DrawMenu.DrawMenuInstruction();
            DrawingConsole.DrawMenu.DoDrawMenu(newDrawMenu);
            if (picture == null)
            {
                NewFile();
                NewDrawMenu();
            }
        }
        public static void ClearPicture()
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.Clear();
            DrawingConsole.DrawMenu.DrawMenuInstruction();
            DrawingConsole.DrawMenu.DoDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
            Console.SetCursorPosition(left, top);
        }
        static void NewFile()
        {
            while (true)
            {
                Console.Clear();
                DrawingConsole.DrawMenu.DrawMenuInstruction();
                DrawingConsole.DrawMenu.DoDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
                Console.SetCursorPosition(DrawingConsole.DrawMenu.LeftPicture, DrawingConsole.DrawMenu.TopPicture);
                Console.Write("Enter name  new file(A-Z,a-z,_): ");
                Console.CursorVisible=true;
                string intput = Console.ReadLine();
                Regex regex = new Regex(@"[A-Z||a-z||_]+");
                if (regex.IsMatch(intput))
                {
                    Console.CursorLeft = DrawingConsole.DrawMenu.LeftPicture;
                    Console.Write("New file create");
                    picture = new Picture(intput);
                    Console.CursorVisible = false;
                    break;
                }
                else{
                    Console.CursorLeft = DrawingConsole.DrawMenu.LeftPicture;
                    Console.Write("Error input");
                    Console.ReadKey();
                }
            }
        }
    }
}
