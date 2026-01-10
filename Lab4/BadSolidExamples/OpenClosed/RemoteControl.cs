using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadSolidExamples.OpenClosed
{
    // Violates open-closed principle: cannot
    // extend remote control's functions without
    // modifying both classes because they're dependent
    // on each other
    public class RemoteControl
    {
        private readonly Light light = new();
        public void ToggleSwitch()
        {
            if (light.State == 1)
            {
                light.TurnOff();
            }
            else if (light.State == 0)
            {
                light.TurnOn();
            }
        }

        public void EnableDim()
        {
            if (light.State != 2)
            {
                light.Dim();
            }
        }
    }
}
