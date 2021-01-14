using System;
using System.Collections.Generic;
using System.Text;

namespace DrawingConsole
{
    public static class Draw
    {
        public static void DrawMenu(string[] menu)
        {
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine($"{i}. {menu[i]}");
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
        }
    }
}
