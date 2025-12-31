using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Torus : IShape
    {
        public double RFull { get; set; }
        public double RTube{ get; set; }
        public bool IsDisplayed { get; set; } = false;
        public Torus(double rFull, double rTube)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(rFull);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(rTube);
            RFull = rFull;
            RTube = rTube;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
