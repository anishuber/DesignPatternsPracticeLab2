using Patterns.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Applications
{
    public class ProxyDemo : IApplication
    {
        public void Run()
        {
            var lockedFile = new LockedFile("""
                       |\      _,,,---,,_
                ZZZzz /,`.-'`'    -.  ;-;;,_
                     |,4-  ) )-,_. ,\ (  `'-'
                    '---''(_/--'  `-'\_)  
                """);
            var admin = new FileProxy(lockedFile, "Admin");
            var you = new FileProxy(lockedFile, "User");

            Console.WriteLine("Administrator view:");
            admin.View();
            Console.WriteLine("User view:");
            you.View();
        }

        public override string ToString()
        {
            return "PROXY";
        }
    }
}
