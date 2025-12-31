using Task1;
using Task2.ChainOfResponsibility;
using Task2.Iterator;
using Task2.Memento;
using Task3;

namespace Driver_Code
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("==== Task 1 ====");

            var shapes = new List<IShape>
            {
                new Sphere(3),
                new Cube(2),
                new Parallelepiped(2,3,4),
                new Torus(5, 1.2),
            };

            var volumeVisitor = new VolumeVisitor();

            foreach (var shape in shapes)
            {
                switch (shape)
                {
                    case Cube cube:
                        cube.Accept(volumeVisitor);
                        Console.WriteLine($"{nameof(Cube)} => V = {volumeVisitor.Volume}");
                        break;

                    case Parallelepiped p:
                        p.Accept(volumeVisitor);
                        Console.WriteLine($"{nameof(Parallelepiped)} => V = {volumeVisitor.Volume}");
                        break;

                    case Sphere sphere:
                        sphere.Accept(volumeVisitor);
                        Console.WriteLine($"{nameof(Sphere)} => V = {volumeVisitor.Volume}");
                        break;

                    case Torus torus:
                        torus.Accept(volumeVisitor);
                        Console.WriteLine($"{nameof(Torus)} => V = {volumeVisitor.Volume}");
                        break;
                }
            }


            Console.WriteLine("==== Task 2 ====");
            Console.WriteLine("==== Chain of Responsibility ====");
            var authenticator = new Authenticator();
            var authorizer = new Authorizer();
            authenticator.SetNext(authorizer);

            var users = new[]
            {
                new User("Sam", 2),
                new User("Sam", 1),
                new User("Jane Doe", 2),
            };

            foreach (var user in users)
            {
                Console.WriteLine($"\nAcces requested: Name={user.Name}, Role={user.Role}");
                authenticator.Handle(user);
            }

            Console.WriteLine("==== Iterator ====");
            var cart = new Cart();
            cart.Push("Milk");
            cart.Push("Bread");
            cart.Push("Cheese");

            var it = cart.CreateIterator();

            Console.WriteLine("Cart items:");
            while (it.HasMore())
            {
                Console.WriteLine($"-> {it.Current()}");
                it.GetNext();
            }

            Console.WriteLine("==== Memento ====");
            var editor = new TextEditor("Title", "Content");
            var history = new TextEditorHistory(editor);

            history.Backup();
            PrintEditor("Initial", editor);

            editor.Write(" + content 2");
            history.Backup();
            PrintEditor("After edit", editor);

            editor.Write(" + content 3");
            history.Backup();
            PrintEditor("After second edit", editor);

            Console.WriteLine("\n--- Undo 2 times ---");
            history.Undo();
            PrintEditor("After first undo", editor);

            history.Undo();
            PrintEditor("After second undo", editor);

            Console.WriteLine("\n--- Redo ---");
            history.Redo();
            PrintEditor("After redo", editor);

            editor.Write(" + content 4");
            history.Backup();
            PrintEditor("After third edit", editor);

            Console.WriteLine("\n--- undo & redo ---");
            history.Undo();
            PrintEditor("After third undo", editor);

            history.Redo();
            PrintEditor("After second redo", editor);

            Console.WriteLine("==== Task 3 ====");
            Task3.Program.Main();
        }

        static void PrintEditor(string title, TextEditor editor)
        {
            Console.WriteLine($"\n{title}:");
            Console.WriteLine($"Title: {editor.Title}");
            Console.WriteLine($"Content: {editor.Content}");
        }
    }
}
