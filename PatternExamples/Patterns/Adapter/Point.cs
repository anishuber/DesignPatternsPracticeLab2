using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
    public class Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double LengthFromStart() => Math.Sqrt(X * X + Y * Y);

        public override string ToString() => $"Point at ({X}, {Y}).";
    }
}
