using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Bridge
{
    public abstract class Spam
    {
        protected ISpammer Spammer { get; private set; }
        public string Recipient { get; set; } = String.Empty;

        protected Spam(ISpammer spammer, string recipient)
        {
            Spammer = spammer ?? throw new ArgumentNullException(nameof(spammer));
            Recipient = recipient ?? throw new ArgumentNullException(nameof(recipient));
        }

        public abstract void SendSpam(string link);
    }
}
