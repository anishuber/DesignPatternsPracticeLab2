using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Bridge
{
    public class EmergencySpam : Spam
    {
        public EmergencySpam(ISpammer spammer, string recipient) : base(spammer, recipient)
        {
        }

        public override void SendSpam(string link)
        {
            Spammer.SendSpam(Recipient, "Hi Grandma,I got into a car accident and need money for the hospital, please send $500 to this CashApp", link);
        }
    }
}
