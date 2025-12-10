using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public interface IPlayer
    {
        string Name { get; }
        int AttackDamage { get; }
        int BreatheUnderwaterSeconds { get; }

        void DisplayStats();
    }
}
