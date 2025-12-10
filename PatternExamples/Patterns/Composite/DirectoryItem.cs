using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Composite
{
    public class DirectoryItem : IFileSystemItem
    {
        public string Name { get; }

        private readonly List<IFileSystemItem> _children = [];

        public DirectoryItem(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Add(IFileSystemItem item)
        {
            ArgumentNullException.ThrowIfNull(item);
            _children.Add(item);
        }

        public void Remove(IFileSystemItem item)
        {
            _children.Remove(item);
        }

        public long GetSize()
        {
            return _children.Sum(child => child.GetSize());
        }

        public void Print(string indent = "")
        {
            Console.WriteLine($"{indent}├─ {Name}/ (total size: {GetSize()} bytes)");

            string childIndent = indent + "│ ";
            foreach (var child in _children)
            {
                child.Print(childIndent);
            }
        }
    }
}
