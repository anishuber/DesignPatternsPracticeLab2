using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Flyweight
{
    public class Unit
    {
        public string Sprite { get; init; }
        public IReadOnlyDictionary<string, int> Stats { get; init; }
        public Unit(string sprite, Dictionary<string, int> stats)
        {
            Sprite = sprite ?? throw new ArgumentNullException(nameof(sprite));
            Stats = stats ?? throw new ArgumentNullException(nameof(stats));
        }

        public void Show()
        {
            Console.WriteLine(Sprite);
            foreach (var kv in Stats)
            {
                Console.WriteLine($"  {kv.Key}: {kv.Value}");
            }
        }
    }
}
