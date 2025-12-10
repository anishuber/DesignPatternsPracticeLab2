using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Bridge
{
    public class EmailSpammer : ISpammer
    {
        public void SendSpam(string recipient, string message, string link)
        {
            Console.WriteLine("=== NEW EMAIL===");
            Console.WriteLine($"to: {recipient}\nbody:\n{message}\n\n<<< {link} >>>\n");
        }
    }
}
