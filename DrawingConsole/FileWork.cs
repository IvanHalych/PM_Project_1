using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using DrawingConsole.Shapes;

namespace DrawingConsole
{
    class FileWork
    {
        public static void Save(Picture picture)
        {
            File.WriteAllText($"{picture.Name}.json",JsonSerializer.Serialize<Picture>(picture));
        }
        public static Picture Read(string name)
        {
            Picture p= JsonSerializer.Deserialize<Picture>(File.ReadAllText($"{name}"));
            List<Shape> list = new List<Shape>();
            p.shapes.ForEach(s =>
            {
                if (s.NameType == "Line")
                {
                    list.Add(new Line(false,s.Points));
                }
                else if (s.NameType == "Circle")
                {
                    list.Add(new Circle(s.Fill,s.Points));
                }
                else if (s.NameType == "ShapeWithManySide")
                {
                    list.Add(new ShapeWithManySide(s.Fill, s.Points));
                }
            });
            p.shapes = list;
            return p;
        }
    }
}
