using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Bridge
{
    public class LotterySpam : Spam
    {
        public LotterySpam(ISpammer spammer, string recipient) 
            : base(spammer, recipient) { }

        public override void SendSpam(string link)
        {
            Spammer.SendSpam(Recipient, "You’ve been nominated for the grand prize of 1000000$! Redeem now", link);
        }
    }
}
