using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DrawingConsole.Shapes
{
    [Serializable]
    public class Point
    {
        [JsonPropertyName("X")]
        public int X { get; set; }
        [JsonPropertyName("Y")]
        public int Y { get; set; }

        public Point()
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static double Length(Point A,Point B)
        {
            return Math.Sqrt(Math.Pow(A.X-B.X,2)+Math.Pow(A.Y-B.Y,2));
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }
    }
}
