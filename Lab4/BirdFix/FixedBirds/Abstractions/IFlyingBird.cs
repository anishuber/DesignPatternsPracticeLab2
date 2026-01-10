using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdFix.FixedBirds.Abstractions
{
    public interface IFlyingBird : IBird
    {
        void Fly();
    }
}
