using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface IShapeObserver
    {
        public void ShapeAddedNotifier(IObservableShape shape);
        public void ShapeChangedNotifier(IObservableShape shape, string propertyName, object? oldValue, object? newValue);
    }
}
