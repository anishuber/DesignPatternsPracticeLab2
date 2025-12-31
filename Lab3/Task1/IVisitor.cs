using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface IVisitor
    {
        public void Visit(Cube cube);
        public void Visit(Paralellepiped paralellepiped);
        public void Visit(Sphere sphere);
        public void Visit(Torus torus);
    }
}
