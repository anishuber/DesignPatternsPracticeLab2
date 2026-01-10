using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSolidExamples.DependencyInversion
{
    public class FileLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
