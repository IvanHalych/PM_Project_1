using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingConsole
{
    public static class Draw
    {
        static int topPicture = 0;
        static int leftPicture = 0;
        public static string[] PresentMenu { get; set; }
        public static int PositionMenu { get; set; } = -1;
        public static void DrawMenu(string[] menu)
        {
            if(PresentMenu!=menu)
            PositionMenu = -1;
            PresentMenu = menu;
            
            Console.SetCursorPosition(0, topPicture);
            int max = 0;
            for (int i = 0; i < menu.Length; i++)
            {
                if (menu[i].Length > max)
                    max = menu[i].Length;
                Console.WriteLine("| "+menu[i]);
            }
            max+=3;
            leftPicture = max + 1;
            Console.SetCursorPosition(max, topPicture);
            for (int i = 0; i < menu.Length; i++)
            {
                Console.SetCursorPosition(max, topPicture + i);
                Console.WriteLine("|");
            }
            for (int i = 0; i <=max; i++)
            {
                Console.Write("-");
            }

        }
        public static void DrawMenuInstruction()
        {
            string str = $"| {(char)0x2191}-up | {(char)0x2193}-down | Enter-enter | Backspase-back | Esc-Exit |";
            for(int i = 0; i < str.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.WriteLine(str);
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            topPicture = Console.CursorTop;
        }

        public static void DrawMenuItemSelect()
        {
            Console.CursorVisible = false;
            DrawMenu(PresentMenu);
            ConsoleColor consoleColor = Console.BackgroundColor;
            Console.BackgroundColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            Console.SetCursorPosition(2, topPicture + PositionMenu);
            Console.Write(PresentMenu[PositionMenu]);
            Console.ResetColor();
        }
    }
}
