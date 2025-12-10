using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Proxy
{
    public class FileProxy : IFile
    {
        private readonly LockedFile _lockedFile;
        private readonly string _userRole;

        public FileProxy(LockedFile lockedFile, string userRole)
        {
            _lockedFile = lockedFile;
            _userRole = userRole;
        }

        public void View()
        {
            if (_userRole == "Admin")
            {
                Console.WriteLine("Access granted\nContent:\n");
                _lockedFile.View();
            }
            else
            {
                Console.WriteLine("Acess denied, no cats today.");
            }
        }
    }
}
