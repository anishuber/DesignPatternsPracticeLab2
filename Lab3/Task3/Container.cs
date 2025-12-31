using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task3
{
    public class Container : IShapeObserver
    {
        public List<IObservableShape> Shapes { get; set; } = [];
        public Container() { }

        public void Add(IObservableShape shape)
        {
            ArgumentNullException.ThrowIfNull(shape);

            Shapes.Add(shape);

            shape.Subscribe(this);

            ShapeAddedNotifier(shape);
        }

        public void Remove(IObservableShape shape)
        {
            ArgumentNullException.ThrowIfNull(shape);

            Shapes.Remove(shape);
            shape.Unsubscribe();    
        }

        public void ShapeAddedNotifier(IObservableShape shape)
        {
            Console.WriteLine($"Added shape: ({shape.Class})");
        }

        public void ShapeChangedNotifier(IObservableShape shape, string propertyName, object? oldValue, object? newValue)
        {
            Console.WriteLine($"Shape changed. {shape.Class}: {oldValue} -> {newValue}");
        }
    }
}
