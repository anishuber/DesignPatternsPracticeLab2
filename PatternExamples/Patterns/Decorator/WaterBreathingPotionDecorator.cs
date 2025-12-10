using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public class WaterBreathingPotionDecorator : PlayerDecorator
    {
        public WaterBreathingPotionDecorator(IPlayer player)
            : base(player) { }

        public override int BreatheUnderwaterSeconds => int.MaxValue;

        public override void DisplayStats()
        {
            Console.WriteLine($"Player {Name}\nattack {AttackDamage}\nbreath underwater unlimited\n");
        }
    }
}
