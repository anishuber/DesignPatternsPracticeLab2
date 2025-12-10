using Patterns.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Applications
{
    public class AdapterDemo : IApplication
    {
        private readonly List<IPoint3D> _points;

        public AdapterDemo()
        {
            _points = [];
        }

        public AdapterDemo(List<IPoint3D> points)
        {
            _points = points;
        }

        public static string DrawPoint(IPoint3D point3D)
        {
            return point3D.ToString() ?? "<empty point>";
        }

        public void AddPoint(IPoint3D point)
        {
            _points.Add(point);
        }

        public void Run()
        {
            foreach (var p in _points)
            {
                Console.WriteLine(DrawPoint(p));
            }
        }

        public override string ToString()
        {
            return "ADAPTER";
        }
    }
}
