using Patterns.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Applications
{
    public class CompositeDemo : IApplication
    {
        private readonly IFileSystemItem _root;

        public CompositeDemo()
        {
            var root = new DirectoryItem("root");

            var docs = new DirectoryItem("docs");
            docs.Add(new FileItem("hometask_Shuber_v2_FIXTHISVERSION.docx", 27_658));
            docs.Add(new FileItem("ffff.txt", 800));

            var images = new DirectoryItem("images");
            images.Add(new FileItem("cat.png", 2_000_000));
            images.Add(new FileItem("jvsdiahdjzk.png", 1_000_000));

            root.Add(docs);
            root.Add(images);
            root.Add(new FileItem("MinecraftServerSetup_stolen.md", 500));

            _root = root;
        }
        public void Run()
        {
            _root.Print();
            Console.WriteLine($"Total size of '{_root.Name}': {_root.GetSize()} bytes");
        }

        public override string ToString()
        {
            return "COMPOSITE";
        }
    }
}
