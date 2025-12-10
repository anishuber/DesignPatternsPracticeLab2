using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Bridge
{
    public class WhatsAppSpammer : ISpammer
    {
        public void SendSpam(string recipient, string message, string link)
        {
            Console.WriteLine($"=== {recipient} You have unread messages ===");
            Console.WriteLine($"{message}\n\n<<< {link} >>>\n");
        }
    }
}
