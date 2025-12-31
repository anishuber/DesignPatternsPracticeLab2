using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task3.ObservableShapes
{
    public class ObservableTorus : Torus, IObservableShape
    {
        private IShapeObserver? _observer;

        public ObservableTorus(double rFull, double rTube) : base(rFull, rTube)
        {
        }

        public string Class => nameof(Torus);

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

        public new double RFull
        {
            get => base.RFull;
            set
            {
                var old = base.RFull;
                base.RFull = value;
                _observer?.ShapeChangedNotifier(this, nameof(RFull), old, value);
            }
        }

        public new double RTube
        {
            get => base.RTube;
            set
            {
                var old = base.RTube;
                base.RTube = value;
                _observer?.ShapeChangedNotifier(this, nameof(RTube), old, value);
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
