using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSolidExamples.InterfaceSegregation
{
    // Violates interface segregation principle
    // because the class implementing the interface
    // cannot actually implement all its requirements
    // + yes I stole it but so did you so it's fair
    public class Penguin : IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("Penguin is eating");
        }

        public void Sleep()
        {
            Console.WriteLine("Penguin is sleeping");
        }

        public void Swim()
        {
            Console.WriteLine("Penguin is swimming");
        }

        public void Fly()
        {
            throw new NotImplementedException("Penguins cannot fly");
        }
    }
}
