using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
    public class Point3D : IPoint3D
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double Distance() => Math.Sqrt(X * X + Y * Y + Z * Z);

        public override string ToString() => $"Point at ({X}, {Y}, {Z}).";
    }
}
