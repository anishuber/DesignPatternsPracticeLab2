using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSolidExamples.LiskovSubstitution
{
    // Violates Liskov's Substitution principle
    // because the child class strengthens parent's
    // constraints and thus cannot be substituted for it
    public class Bicycle : Vehicle
    {
        public override void Drive(int miles)
        {
            if (miles > 0 && miles < 10)
            {
                base.Drive(miles);
            }
        }
    }
}
