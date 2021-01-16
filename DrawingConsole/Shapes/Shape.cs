using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DrawingConsole.Shapes
{
    [Serializable]
    public abstract class Shape
    {
        public Shape(int position)
        {
            Position = position;
        }
        [JsonPropertyName("Name")]
        public string NameType { get; set; }
        [JsonPropertyName("Points")]
        public Point[] Points { get; set; }
        public int Position { get; set; }
        public virtual double Square { get; }
        public virtual double Perimeter { get; }
    }
}
