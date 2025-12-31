using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Cube : IShape
    {
        public double A { get; set; }
        public bool IsDisplayed { get; set; } = false;

        public Cube(double a)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(a);
            A = a;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
