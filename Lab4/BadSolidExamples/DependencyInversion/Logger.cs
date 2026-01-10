using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSolidExamples.DependencyInversion
{
    // Violates depoendency inversion principle
    // because now any changes in FileLogger may
    // affect the Logger class and it is supposed
    // to be high level
    public class Logger
    {
        private readonly FileLogger _logger = new FileLogger();

        public void Log(string message)
        {
            _logger.Log(message);
        }
    }
}
