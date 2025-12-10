using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Flyweight
{
    public class MovingUnit
    {
        private readonly Unit _unit;
        private int _x;
        private int _y;
        public MovingUnit(int x, int y, Unit unit)
        {
            _x = x;
            _y = y;
            _unit = unit ?? throw new ArgumentNullException(nameof(unit));
        }

        public void Move(int dx, int dy)
        {
            _x += dx;
            _y += dy;
            Console.WriteLine($"\n* moved to ({_x}, {_y}) *");
        }

        public void Render()
        {
            Console.WriteLine($"\nImagine it is at ({_x}, {_y})");
            _unit.Show();
        }
    }
}
