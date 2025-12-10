using Patterns.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Applications
{
    public class DecoratorDemo : IApplication
    {
        private IPlayer _player;
        public DecoratorDemo(IPlayer player) => _player = player ?? throw new ArgumentNullException(nameof(player));

        public void ApplyWaterBreathing()
        {
            _player = new WaterBreathingPotionDecorator(_player);
        }

        public void ApplyStrength()
        {
            _player = new StrengthPotionDecorator(_player);
        }

        public void Run()
        {
            Console.WriteLine("Initial stats:");
            _player.DisplayStats();
            ApplyStrength();
            Console.WriteLine("After applying strength:");
            _player.DisplayStats();
            ApplyWaterBreathing();
            Console.WriteLine("After applying water breathing:");
            _player.DisplayStats();

            while (_player is PlayerDecorator decorator)
            {
                _player = decorator.Player;
            }
            Console.WriteLine("After all potions expired:");
            _player.DisplayStats();
        }

        public override string ToString()
        {
            return "DECORATOR";
        }
    }
}
