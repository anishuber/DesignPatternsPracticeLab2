using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task3
{
    public interface IObservableShape
    {
        string Class { get; }
        void Subscribe(IShapeObserver observer);
        void Unsubscribe();
    }
}
