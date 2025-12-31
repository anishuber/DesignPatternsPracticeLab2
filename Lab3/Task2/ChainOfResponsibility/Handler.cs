using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.ChainOfResponsibility
{
    public abstract class Handler
    {
        private Handler _nextHandler;

        public Handler SetNext(Handler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public void Handle(User user)
        {
            if (DoHandle(user))
            {
                return;
            }

            _nextHandler?.Handle(user);
        }

        public abstract bool DoHandle(User user);
    }
}
