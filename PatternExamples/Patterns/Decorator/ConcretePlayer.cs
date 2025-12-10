using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public class ConcretePlayer : IPlayer
    {
        public string Name { get; set; }

        public int AttackDamage => 5;

        public int BreatheUnderwaterSeconds => 15;

        public ConcretePlayer(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void DisplayStats()
        {
            Console.WriteLine($"Player {Name}\nattack {AttackDamage}\nbreath underwater {BreatheUnderwaterSeconds} sec.\n");
        }
    }
}
