using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Flyweight
{
    public class UnitFactory
    {
        private readonly Dictionary<string, Unit> _cache = new();

        public Unit GetUnit(string type)
        {
            if (_cache.TryGetValue(type, out var unit))
                return unit;

            unit = type switch
            {
                "Knight" => new Unit("""
                       O   
                      (|)  /
                     / | \/
                      / \
                    """,
                    new Dictionary<string, int> { { "Defence", 16 }, { "Attack", 11 } }),

                "Archer" => new Unit("""
                        \
                    O  / \
                   <|\---)
                    |  \ /
                   / \  /
                   """,
                    new Dictionary<string, int> { { "Defence", 1 }, { "Attack", 5 } }),

                 _ => throw new ArgumentException($"Unknown unit type: {type}")
            };

            _cache[type] = unit;
            return unit;
        }
    }
}
