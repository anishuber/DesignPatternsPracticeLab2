using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
    public class PointToPoint3DAdapter : IPoint3D
    {
        private readonly Point _point;
        private readonly double _z;

        public PointToPoint3DAdapter(Point point) 
            : this(point, 0.0)
        {
        }

        public PointToPoint3DAdapter(Point point, double z)
        {
            _point = point ?? throw new ArgumentNullException(nameof(point));
            _z = z;
        }

        public double X => _point.X;
        public double Y => _point.Y;
        public double Z => _z;

        public double Distance() => Math.Sqrt(X * X + Y * Y + Z * Z);

        public override string ToString() => $"Point at ({_point.X}, {_point.Y}, {_z}) (adapted from 2D).";
    }
}
    