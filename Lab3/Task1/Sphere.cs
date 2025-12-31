using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Sphere : IShape
    {
        public double R;
        public bool IsDisplayed { get; set; } = false;
        public Sphere(double r)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(r);
            R = r;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
