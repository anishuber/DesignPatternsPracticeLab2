using BirdFix.FixedBirds.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdFix.FixedBirds.Birds
{
    public class Penguin : IWalkingBird
    {
        public void Dance()
        {
            Console.WriteLine("Raving, dancing with the dead");
        }

        public void DefendEgg()
        {
            Console.WriteLine("Insanity reigned and spilled the first blood");
        }

        public void ProduceEgg()
        {
            Console.WriteLine("Typing practically anything here will be an HR violation, so the egg is produced silently");
        }

        public void SearchForSpouse()
        {
            Console.WriteLine("True hope lies beyond the coast");
        }

        public void Sing()
        {
            Console.WriteLine("Insert any Alice Cooper song here");
        }

        public void Walk()
        {
            Console.WriteLine("Run to the hills");
        }
    }
}
