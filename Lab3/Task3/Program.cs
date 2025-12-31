using Task1;
using Task3.ObservableShapes;

namespace Task3
{
    public class Program
    {
        public static void Main()
        {
            var container = new Container();

            var s = new ObservableSphere(4);
            var t = new ObservableTorus(10, 2);

            container.Add(t);
            container.Add(s);

            s.R = 10;
            s.IsDisplayed = true;
            t.RTube = 5;
        }
    }
}
