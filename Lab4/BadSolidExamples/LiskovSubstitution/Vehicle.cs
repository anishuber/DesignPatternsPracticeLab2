using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSolidExamples.LiskovSubstitution
{
    public abstract class Vehicle
    {
        public virtual void Drive(int miles)
        {
            if (miles > 0 && miles < 300)
            {
                Console.WriteLine("Vehicle driving");
            }
        }
    }
}
