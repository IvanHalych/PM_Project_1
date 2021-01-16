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
        public static void Save(string name, Shape[] shapes)
        {
            File.WriteAllText($"{name}.json",JsonSerializer.Serialize<Shape[]>(shapes));
        }
        public static Shape[] Read(string name)
        {
            return JsonSerializer.Deserialize<Shape[]>(File.ReadAllText($"{name}.json"));
        }
    }
}
