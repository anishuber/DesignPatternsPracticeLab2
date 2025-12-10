using Patterns.Flyweight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Applications
{
    public class FlyweightDemo : IApplication
    {
        private readonly List<MovingUnit> _units;
        public FlyweightDemo(IEnumerable<(string type, int x, int y)> unitData)
        {
            if (unitData is null) throw new ArgumentNullException(nameof(unitData));

            var factory = new UnitFactory();
            _units = [];

            foreach (var (type, x, y) in unitData)
            {
                var flyweight = factory.GetUnit(type);
                _units.Add(new MovingUnit(x, y, flyweight));
            }
        }
        public void Run()
        {
            foreach (var unit in _units)
            {
                unit.Render();
                unit.Move(2, 2);
                unit.Render();
            }
        }

        public override string ToString()
        {
            return "FLYWEIGHT";
        }
    }
}
