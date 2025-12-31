using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class VolumeVisitor : IVisitor
    {
        public double Volume { get; set; }
        public VolumeVisitor() { }

        public void Visit(Cube cube)
        {
            Volume = Math.Pow(cube.A, 3);
        }

        public void Visit(Paralellepiped paralellepiped)
        {
            Volume = paralellepiped.A * paralellepiped.B * paralellepiped.C;
        }

        public void Visit(Sphere sphere)
        {
            Volume = 4 / 3 * Math.PI * sphere.R * sphere.R;
        }

        public void Visit(Torus torus)
        {
            Volume = 2 * Math.PI * Math.PI * torus.RFull * torus.RTube * torus.RTube;
        }
    }
}
