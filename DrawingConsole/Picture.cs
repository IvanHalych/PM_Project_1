﻿using System;
using System.Collections.Generic;
using System.Text;
using DrawingConsole.Shapes;
using System.Text.Json.Serialization;

namespace DrawingConsole
{
    public class Picture
    {
        public Picture()
        {
        }

        public Picture(string name)
        {
            Name = name;
        }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Shapes")]
        public List<Shape> shapes { get; set; } = new List<Shape>();
    }
}
