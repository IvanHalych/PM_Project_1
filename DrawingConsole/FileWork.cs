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
            return JsonSerializer.Deserialize<Picture>(File.ReadAllText($"{name}.json"));
        }
    }
}
