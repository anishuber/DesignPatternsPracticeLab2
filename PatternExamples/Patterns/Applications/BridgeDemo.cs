using Patterns.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Applications
{
    public class BridgeDemo : IApplication
    {
        public delegate Spam SpamFactory(ISpammer spammer, string recipient);
        private readonly string[] _recipients;
        private readonly string _link;

        public BridgeDemo(string[] recipients, string link)
        {
            _recipients = recipients ?? throw new ArgumentNullException(nameof(recipients));
            _link = link ?? throw new ArgumentNullException(nameof(link));
        }

        public void Run()
        {
            var spamFactories = new List<SpamFactory>
            {
                (spammer, recipient) => new LotterySpam(spammer, recipient),
                (spammer, recipient) => new EmergencySpam(spammer, recipient),
                (spammer, recipient) => new GitRepoSpam(spammer, recipient),
            };

            foreach (var recipient in _recipients)
            {
                ISpammer spammer;

                if (recipient.Contains('@'))
                {
                    spammer = new EmailSpammer();
                }
                else
                {
                    spammer = new WhatsAppSpammer();
                }

                foreach (var spamFactory in spamFactories)
                {
                    var spam = spamFactory(spammer, recipient);
                    spam.SendSpam(_link);
                }
            }
        }

        public override string ToString()
        {
            return "BRIDGE";
        }
    }
}
