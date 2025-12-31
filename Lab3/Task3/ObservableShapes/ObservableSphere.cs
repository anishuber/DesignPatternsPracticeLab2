using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task3.ObservableShapes
{
    public class ObservableSphere : Sphere, IObservableShape
    {
        private IShapeObserver? _observer;

        public ObservableSphere(double r) : base(r)
        {
        }

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

        public new double R
        {
            get => base.R;
            set
            {
                var old = base.R;
                base.R = value;
                _observer?.ShapeChangedNotifier(this, nameof(R), old, value);
            }
        }

        public string Class => nameof(Sphere);

        public void Subscribe(IShapeObserver observer)
        {
            ArgumentNullException.ThrowIfNull(nameof(observer));
            _observer = observer;
        }
        public void Unsubscribe() => _observer = null;
    }
}
