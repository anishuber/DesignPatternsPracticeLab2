
using Task2.Clients;
using Task2.Data;
using Task2.Interfaces;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = BuildApp.BuildWebApplication(args);
            app.Run();
        }
    }
}
