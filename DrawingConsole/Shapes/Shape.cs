using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DrawingConsole.Shapes
{
    public class Shape
    {
        public Shape()
        {
        }

        public bool Fill { get; set; }

        [JsonPropertyName("Name")]
        public string NameType { get; set; }
        [JsonPropertyName("Points")]
        public List<Point> Points { get; set; }
        public virtual double Square { get; }
        public virtual double Perimeter { get; }

        public virtual void Draw(int position) { }
    }
}
