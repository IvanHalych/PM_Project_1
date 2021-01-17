using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
                    Console.Write("File open");
                    picture = FileWork.Read(intput);
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
            picture = new Picture("aaa");
            picture.shapes.Add(DrawPicture.CreateLine());
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
        }
        public static void ClearPicture()
        {
            Console.Clear();
            DrawingConsole.DrawMenu.DrawMenuInstruction();
            DrawingConsole.DrawMenu.DoDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
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
