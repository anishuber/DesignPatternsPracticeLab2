using Patterns.Adapter;
using Patterns.Applications;
using Patterns.Decorator;
using Patterns.Facade;
using System.Collections.Generic;

namespace DriverCode
{
    static class Program
    {
        static void Main(string[] args)
        {
            var facade = new AllPatternsFacade();

            Console.WriteLine($"========== EVERYTHING BELOW IS A FACADE EXAMPLE ==========");
            facade.RunAll();
            facade.RunOnly<BridgeDemo>();
        }
    }
}