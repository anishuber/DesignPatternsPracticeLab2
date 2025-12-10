using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Decorator
{
    public class PlayerDecorator : IPlayer
    {
        public IPlayer Player { get; init; }
        protected PlayerDecorator(IPlayer player)
        {
            Player = player ?? throw new ArgumentNullException(nameof(player));
        }
        public string Name => Player.Name;

        public virtual int AttackDamage => Player.AttackDamage;

        public virtual int BreatheUnderwaterSeconds => Player.BreatheUnderwaterSeconds;

        public virtual void DisplayStats() => Player.DisplayStats();
    }
}
