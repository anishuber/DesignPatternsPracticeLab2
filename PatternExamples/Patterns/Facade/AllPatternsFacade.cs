using Patterns.Adapter;
using Patterns.Applications;
using Patterns.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Facade
{
    public class AllPatternsFacade
    {
        private readonly List<IApplication> _apps = [];

        public AllPatternsFacade()
        {
            IPoint3D point3D = new Point3D(0.1, 2.2, 9.0);
            IPoint3D point2D = new PointToPoint3DAdapter(new Point(3.5, 2.4));
            _apps.Add(new AdapterDemo([point2D, point3D]));

            var recipients = new string[] { "+1234567", "70u2m0m947@gmail.com" };
            _apps.Add(new BridgeDemo(recipients, "https://e122d0no7clickme.z1.web.core.windows.net/"));

            _apps.Add(new CompositeDemo());
            _apps.Add(new DecoratorDemo(new ConcretePlayer("Steve")));

            var unitData = new (string type, int x, int y)[]
            {
            ("Archer", 0, 0),
            ("Archer", 5, 5),
            ("Knight", 10, -1),
            };
            _apps.Add(new FlyweightDemo(unitData));

            _apps.Add(new ProxyDemo());
        }

        public void RunOnly<TDemo>() where TDemo : IApplication
        {
           RunApps(_apps.Where(a => a is TDemo));
        }

        public void RunAll()
        {
            RunApps(_apps);
        }

        private static void RunApps(IEnumerable<IApplication> apps)
        {
            foreach (var app in apps)
            {
                Console.WriteLine($"\n\n========== {app} EXAMPLE ==========\n\n");
                app.Run();
            }
        }
    }
}
