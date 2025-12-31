using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task3.ObservableShapes
{
    public class ObservableCube : Cube, IObservableShape
    {
        private IShapeObserver? _observer;
        public ObservableCube(double a) : base(a)
        {
        }

        public string Class => nameof(Cube);

        public new bool IsDisplayed
        {
            get => base.IsDisplayed;
            set
            {
                var old = base.IsDisplayed;
                base.IsDisplayed = value;
                _observer?.ShapeChangedNotifier(this, nameof(IsDisplayed), old, value);
            }
        }

        public new double A
        {
            get => base.A;
            set
            {
                var old = base.A;
                base.A = value;
                _observer?.ShapeChangedNotifier(this, nameof(A), old, value);
            }
        }

        public void Subscribe(IShapeObserver observer)
        {
            ArgumentNullException.ThrowIfNull(nameof(observer));
            _observer = observer;
        }

        public void Unsubscribe() => _observer = null;
    }
}
