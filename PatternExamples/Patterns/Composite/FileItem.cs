using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Composite
{
    public class FileItem : IFileSystemItem
    {
        public string Name { get; }
        private readonly long _sizeBytes;

        public FileItem(string name, long sizeBytes)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _sizeBytes = sizeBytes;
        }

        public long GetSize() => _sizeBytes;
        public void Print(string indent = "")
        {
            Console.WriteLine($"{indent}└── {Name} ({_sizeBytes} bytes)");
        }
    }
}
