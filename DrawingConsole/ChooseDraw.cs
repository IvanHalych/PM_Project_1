using System;
using System.Collections.Generic;
using System.Text;
using DrawingConsole.Exceptions;
using DrawingConsole.Shapes;

namespace DrawingConsole
{
    public static class ChooseDraw
    {
        static readonly string MenuDrawInstruction = $"| {(char)0x2190}-left | {(char)0x2191}-up | {(char)0x2192}-right | {(char)0x2193}-down | Enter-Choose | Backspase-back | Esc-Exit |";
        static readonly string MenuDrawInstruction1 = $"| {(char)0x2190}-left | {(char)0x2191}-up | {(char)0x2192}-right | {(char)0x2193}-down | Enter-Save | Backspase-back | Esc-Exit |";
        static readonly string MenuDrawInstructionDelete = $"| {(char)0x2190}-left | {(char)0x2191}-up | {(char)0x2192}-right | {(char)0x2193}-down | Enter-Delete | Backspase-back | Esc-Exit |";

        public static Picture ChooseDelete(Picture picture)
        {
            int position = 0;
            DrawingConsole.DrawMenu.PresentInstruction =MenuDrawInstructionDelete;
            Drawing.ClearPicture();
            DrawChoose(picture.shapes, position);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (picture.shapes.Count - 1 > position)
                        {
                            position++;
                            DrawChoose(picture.shapes, position);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (position > 0)
                        {
                            position--;
                            DrawChoose(picture.shapes, position);
                        }
                        break;
                    case ConsoleKey.Enter:
                        picture.shapes.RemoveAt(picture.shapes.Count - 1 - position);
                        return picture;
                    case ConsoleKey.Escape:
                        throw new ExitException();
                    case ConsoleKey.Backspace:
                        return picture;
                }
            }
        }
        public static Picture ChooseChosen(Picture picture)
        {
            DrawingConsole.DrawMenu.PresentInstruction = MenuDrawInstruction;
            Drawing.ClearPicture();
            int position = 0;
            DrawChoose(picture.shapes, position);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (picture.shapes.Count-1 > position)
                        {
                            position++;
                            DrawChoose(picture.shapes, position);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (position > 0)
                        {
                            position--;
                            DrawChoose(picture.shapes, position);
                        }
                        break;
                    case ConsoleKey.Enter:
                        return ChangeChosen(picture,position);
                    case ConsoleKey.Escape:
                        throw new ExitException();
                    case ConsoleKey.Backspace:
                        return picture;
                }
            }
        }
        static Picture ChangeChosen(Picture picture,int position)
        {
            DrawingConsole.DrawMenu.PresentInstruction = MenuDrawInstruction1;
            Drawing.ClearPicture();
            DrawChoose(picture.shapes, position);
            List<Shape> shapes = new List<Shape>(picture.shapes);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        shapes[shapes.Count - 1 - position].Points.ForEach(s=>s.Y++);
                        DrawChoose(shapes, position);
                        break;
                    case ConsoleKey.UpArrow:
                        shapes[shapes.Count - 1 - position].Points.ForEach(s => s.Y--);
                        DrawChoose(shapes, position);
                        break;
                    case ConsoleKey.LeftArrow:
                        shapes[shapes.Count - 1 - position].Points.ForEach(s => s.X--);
                        DrawChoose(shapes, position);
                        break;
                    case ConsoleKey.RightArrow:
                        shapes[shapes.Count - 1 - position].Points.ForEach(s => s.X++);
                        DrawChoose(shapes, position);
                        break;
                    case ConsoleKey.Enter:
                        picture.shapes = shapes;
                        return picture;
                    case ConsoleKey.Backspace:
                        return picture;
                    case ConsoleKey.Escape:
                        throw new ExitException();
                }
            }
        }
        public static void DrawChoose(List<Shape> shapes,int position)
        {
            Drawing.ClearPicture();
            DrawPicture.DrawShapes(shapes);
            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = consoleColor;
            shapes[shapes.Count - 1 - position].Draw(position);
            Console.ResetColor();
        }
    }
}
