using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdFix.FixedBirds.Abstractions
{
    public interface IWalkingBird : IBird
    {
        void Dance();
        void Walk();
    }
}
