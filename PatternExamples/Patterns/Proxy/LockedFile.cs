using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Proxy
{
    public class LockedFile : IFile
    {
        private readonly string _content;

        public LockedFile(string content)
        {
            _content = content;
        }
        public void View()
        {
            Console.WriteLine(_content);
        }
    }
}
