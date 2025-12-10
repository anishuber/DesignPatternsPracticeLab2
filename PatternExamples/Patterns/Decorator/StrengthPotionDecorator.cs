using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public class StrengthPotionDecorator : PlayerDecorator
    {
        public StrengthPotionDecorator(IPlayer player)
        : base(player) { }

        public override int AttackDamage => Player.AttackDamage + 5;

        public override void DisplayStats()
        {
            Console.WriteLine($"Player {Name}\nattack {AttackDamage}\nbreath underwater {BreatheUnderwaterSeconds} sec.\n");
        }
    }
}
