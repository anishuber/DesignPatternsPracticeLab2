using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
    public interface IPoint3D
    {
        double X { get; }
        double Y { get; }
        double Z { get; }

        double Distance();
        string ToString();
    }
}
