using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DrawingConsole.Exceptions;
using DrawingConsole.Shapes;

namespace DrawingConsole
{
    public static class Drawing
    {
        static readonly string[] headMenu = new string[] { "File", "Draw" };
        static readonly string[] fileMenu = new string[] { "NewFile", "Open", "Save" };
        static readonly string[] drawMenu = new string[] { "NewDraw", "ChangeDraw", "DeleteDraw", "Sort" };
        static readonly string[] newDrawMenu = new string[] { "Line", "Circle", "Shape With Many Side" };
        static readonly string MenuInstruction = $"| {(char)0x2191}-up | {(char)0x2193}-down | Enter-enter | Backspase-back | Esc-Exit |";
        static Dictionary<string, Action> pairs = new Dictionary<string, Action>();
        static Stack<string[]> StackMenu;
        static Picture picture = new Picture();
        static Dictionary<string, Action> GetSetting()
        {
            var pairs = new Dictionary<string, Action>
            {
                { "File", FileMenu },
                { "Draw", DrawMenu },
                { "NewDraw", NewDrawMenu },
                { "Line", CreateLine },
                { "Circle", CreateCircle },
                { "Shape With Many Side", CreateShape },
                { "NewFile", NewFile },
                { "Save", Save },
                { "Open", Open },
                { "DeleteDraw", DeleteDraw },
                { "ChangeDraw", ChangeDraw },
                { "Sort", Sort }
            };
            return pairs;
        }
        public static void Run ()
        {
            StackMenu= new Stack<string[]>();
            Console.CursorVisible = false;
            Console.ResetColor();
            pairs = GetSetting();
            DrawingConsole.DrawMenu.PresentInstruction=MenuInstruction;
            DrawingConsole.DrawMenu.PresentMenu=headMenu;
            ClearPicture();
            while (true)
            {
              
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (DrawingConsole.DrawMenu.PositionMenu != DrawingConsole.DrawMenu.PresentMenu.Length - 1)
                        {
                            DrawingConsole.DrawMenu.PositionMenu++;
                            DrawingConsole.DrawMenu.DrawMenuItemSelect(picture);

                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (DrawingConsole.DrawMenu.PositionMenu != 0 && DrawingConsole.DrawMenu.PositionMenu != -1)
                        {
                            DrawingConsole.DrawMenu.PositionMenu--;
                            DrawingConsole.DrawMenu.DrawMenuItemSelect(picture);
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (DrawingConsole.DrawMenu.PositionMenu != -1)
                        {
                            try
                            {
                                pairs.GetValueOrDefault(DrawingConsole.DrawMenu.PresentMenu[DrawingConsole.DrawMenu.PositionMenu]).Invoke();
                            }
                            catch (ExitException)
                            {
                                Console.Clear();
                                return;
                            }
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

        private static void Sort()
        {
            while (true)
            {
                ClearPicture();
                Console.SetCursorPosition(DrawingConsole.DrawMenu.LeftPicture, DrawingConsole.DrawMenu.TopPicture);
                Console.Write("Sort by(Square/Perimeter): ");
                Console.CursorVisible = true;
                string input = Console.ReadLine();
                if (input == "Square")
                {
                    while (true)
                    {
                        Console.CursorLeft = DrawingConsole.DrawMenu.LeftPicture;
                        Console.Write("Sort by(up/down): ");
                        input = Console.ReadLine();
                        if (input == "up")
                        {
                            picture.shapes = picture.shapes.OrderBy(p => p.Square).ToList();
                            break;
                        }
                        else if (input == "down")
                        {
                            picture.shapes = picture.shapes.OrderByDescending(p => p.Square).ToList();
                            break;
                        }
                        else
                        {
                            Console.CursorLeft = DrawingConsole.DrawMenu.LeftPicture;
                            Console.Write("Error input");
                            Console.ReadKey();

                        }
                    }
                    break;
                }
                else if (input == "Perimeter")
                {
                    while (true)
                    {
                        Console.CursorLeft = DrawingConsole.DrawMenu.LeftPicture;
                        Console.Write("Sort by(up/down): ");
                        input = Console.ReadLine();
                        if (input == "up")
                        {
                            picture.shapes = picture.shapes.OrderBy(p => p.Perimeter).ToList();
                            break;

                        }
                        else if (input == "down")
                        {
                            picture.shapes = picture.shapes.OrderByDescending(p => p.Perimeter).ToList();
                            break;

                        }
                        else
                        {
                            Console.CursorLeft = DrawingConsole.DrawMenu.LeftPicture;
                            Console.Write("Error input");
                            Console.ReadKey();
                        }
                    }
                    break;
                }
                else
                {
                    Console.CursorLeft = DrawingConsole.DrawMenu.LeftPicture;
                    Console.Write("Error input");
                    Console.ReadKey();
                }
            }
            DrawingConsole.DrawMenu.PresentInstruction = MenuInstruction;
            DrawPicture.DrawShapes(picture.shapes);
        }


        private static void ChangeDraw()
        {
            picture = ChooseDraw.ChooseChosen(picture);
            DrawingConsole.DrawMenu.PresentInstruction = MenuInstruction;
            DrawPicture.DrawShapes(picture.shapes);
        }

        private static void DeleteDraw()
        {
            picture = ChooseDraw.ChooseDelete(picture);
            DrawingConsole.DrawMenu.PresentInstruction = MenuInstruction;
            DrawPicture.DrawShapes(picture.shapes);
        }

        private static void CreateShape()
        {
            while (true)
            {
                ClearPicture();
                Console.SetCursorPosition(DrawingConsole.DrawMenu.LeftPicture, DrawingConsole.DrawMenu.TopPicture);
                Console.Write("How draw Shape(fill/empty): ");
                Console.CursorVisible = true;
                string input = Console.ReadLine();
                if (input == "fill")
                {
                    picture = DrawPicture.CreateShape<ShapeWithManySide>(picture, true, "ShapeWithManySide");
                    Console.CursorVisible = false;
                    break;
                }
                else if (input == "empty")
                {
                    picture = DrawPicture.CreateShape<ShapeWithManySide>(picture, false, "ShapeWithManySide");
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
            DrawingConsole.DrawMenu.PresentInstruction = MenuInstruction;
            DrawPicture.DrawShapes(picture.shapes);
        }

        private static void CreateCircle()
        {
            while (true)
            {
                Console.Clear();
                DrawingConsole.DrawMenu.DrawMenuInstruction(MenuInstruction);
                DrawingConsole.DrawMenu.TryDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
                Console.SetCursorPosition(DrawingConsole.DrawMenu.LeftPicture, DrawingConsole.DrawMenu.TopPicture);
                Console.Write("How draw Circle(fill/empty): ");
                Console.CursorVisible = true;
                string input = Console.ReadLine();
                if (input == "fill")
                {
                    Console.Clear();
                    DrawingConsole.DrawMenu.DrawMenuInstruction(MenuInstruction);
                    DrawingConsole.DrawMenu.TryDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
                    picture = DrawPicture.CreateShape<Circle>(picture, true, "Circle");
                    Console.CursorVisible = false;
                    break;
                }
                else if (input == "empty")
                {
                    Console.Clear();
                    DrawingConsole.DrawMenu.DrawMenuInstruction(MenuInstruction);
                    DrawingConsole.DrawMenu.TryDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
                    picture = DrawPicture.CreateShape<Circle>(picture, false, "Circle");
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
            DrawingConsole.DrawMenu.PresentInstruction = MenuInstruction;
            DrawPicture.DrawShapes(picture.shapes);
        }

        private static void Open()
        {
            while (true)
            {
                Console.Clear();
                DrawingConsole.DrawMenu.DrawMenuInstruction(MenuInstruction);
                DrawingConsole.DrawMenu.TryDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
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
                    catch (FileNotFoundException)
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
            DrawPicture.DrawShapes(picture.shapes);
        }

        private static void Save()
        {
            FileWork.Save(picture);
            ClearPicture();
            Console.SetCursorPosition(DrawingConsole.DrawMenu.LeftPicture, DrawingConsole.DrawMenu.TopPicture);
            Console.Write("File save as " + picture.Name+".json");
            Console.ReadKey();
            DrawPicture.DrawShapes(picture.shapes);
        }

        private static void CreateLine()
        {
            picture = DrawPicture.CreateShape<Line>(picture, false, "Line");
            DrawingConsole.DrawMenu.PresentInstruction = MenuInstruction;
            DrawPicture.DrawShapes(picture.shapes);
        }

        private static void BackSpaceMenu()
        {
            Console.Clear();
            DrawingConsole.DrawMenu.PresentInstruction=MenuInstruction;
            if(StackMenu.Count !=0)
                DrawingConsole.DrawMenu.PresentMenu =StackMenu.Pop();
            else
                DrawingConsole.DrawMenu.PresentMenu =headMenu;
            DrawPicture.DrawShapes(picture.shapes);
        }

        static void FileMenu()
        {
            StackMenu.Push(DrawingConsole.DrawMenu.PresentMenu);
            DrawingConsole.DrawMenu.PresentMenu=fileMenu;
            DrawPicture.DrawShapes(picture.shapes);
        }
        static void DrawMenu()
        { 
            StackMenu.Push(DrawingConsole.DrawMenu.PresentMenu);
            DrawingConsole.DrawMenu.PresentMenu = drawMenu;
            DrawPicture.DrawShapes(picture.shapes);
        }
        static void NewDrawMenu()
        {

            StackMenu.Push(DrawingConsole.DrawMenu.PresentMenu);
            DrawingConsole.DrawMenu.PresentMenu = newDrawMenu;
            ClearPicture();
            if (picture.Name == null)
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
            DrawingConsole.DrawMenu.DrawMenuInstruction(DrawingConsole.DrawMenu.PresentInstruction);
            DrawingConsole.DrawMenu.TryDrawMenu(DrawingConsole.DrawMenu.PresentMenu);
            Console.SetCursorPosition(left, top);
        }
        static void NewFile()
        {
            while (true)
            {
                ClearPicture();
                Console.SetCursorPosition(DrawingConsole.DrawMenu.LeftPicture, DrawingConsole.DrawMenu.TopPicture);
                Console.Write("Enter name new file(A-Z,a-z,_): ");
                Console.CursorVisible = true;
                string intput = Console.ReadLine();
                Regex regex = new Regex(@"[A-Z||a-z||_]+");
                if (regex.IsMatch(intput))
                {
                    Console.CursorLeft = DrawingConsole.DrawMenu.LeftPicture;
                    Console.Write("New file create");
                    picture = new Picture(intput);
                    Console.ReadKey();
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
            ClearPicture();
        }
    }
}
