using System;
using System.Collections.Generic;

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

        static void Main()
        {
            Console.ResetColor();
            pairs.Add("File", FileMenu);
            pairs.Add("Draw", DrawMenu);
            pairs.Add("NewDraw", NewDrawMenu);
            Draw.DrawMenuInstruction();
            Draw.DrawMenu(headMenu);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if(Draw.PositionMenu != Draw.PresentMenu.Length-1)
                        {
                            Draw.PositionMenu++;
                            Draw.DrawMenuItemSelect();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (Draw.PositionMenu != 0&&Draw.PositionMenu!=-1)
                        {
                            Draw.PositionMenu--;
                            Draw.DrawMenuItemSelect();
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (Draw.PositionMenu != -1)
                        {
                            pairs.GetValueOrDefault(Draw.PresentMenu[Draw.PositionMenu]).Invoke();
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

        private static void BackSpaceMenu()
        {
            Console.Clear();
            Draw.DrawMenuInstruction();
            Draw.DrawMenu(StackMenu.Pop());
        }

        static void FileMenu()
        {
            StackMenu.Push(Draw.PresentMenu);
            Console.Clear();
            Draw.DrawMenuInstruction();
            Draw.DrawMenu(fileMenu);
        }
        static void DrawMenu()
        {
            StackMenu.Push(Draw.PresentMenu);
            Console.Clear();
            Draw.DrawMenuInstruction();
            Draw.DrawMenu(drawMenu);
        }
        static void NewDrawMenu()
        {
            StackMenu.Push(Draw.PresentMenu);
            Console.Clear();
            Draw.DrawMenuInstruction();
            Draw.DrawMenu(newDrawMenu);
        }
    }
}
