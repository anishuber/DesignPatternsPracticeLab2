using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Bridge
{
    public class GitRepoSpam : Spam
    {
        public GitRepoSpam(ISpammer spammer, string recipient) 
            : base(spammer, recipient) { }

        public override void SendSpam(string link)
        {
            Spammer.SendSpam(Recipient, "Hey!\nTake a look at my amazing Github page:", link);
        }
    }
}
