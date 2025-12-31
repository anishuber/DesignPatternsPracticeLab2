using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Iterator
{
    public interface IProductIterator<out T>
    {
        void GetNext();
        bool HasMore();
        T Current();
    }
}
