using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Paralellepiped : IShape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public bool IsDisplayed { get; set; } = false;

        public Paralellepiped(double a, double b, double c)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(a);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(b);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(c);

            A = a;
            B = b;
            C = c;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
