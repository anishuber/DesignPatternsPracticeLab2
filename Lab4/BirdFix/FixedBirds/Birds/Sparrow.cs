using BirdFix.FixedBirds.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdFix.FixedBirds.Birds
{
    public class Sparrow : IFlyingBird, IWalkingBird
    {
        public void Dance()
        {
            Console.WriteLine("Move the body");
        }

        public void DefendEgg()
        {
            Console.WriteLine("Dum dum dum, it's the sound of my gun");
        }

        public void Fly()
        {
            Console.WriteLine("Fly away, far away");
        }

        public void ProduceEgg()
        {
            Console.WriteLine("Typing practically anything here will be an HR violation, so the egg is produced silently");
        }

        public void SearchForSpouse()
        {
            Console.WriteLine("Hey, you, out there on your own");
        }

        public void Sing()
        {
            Console.WriteLine("Sing for the laughter and sing for the tear");
        }

        public void Walk()
        {
            Console.WriteLine("And walk away");
        }
    }
}
