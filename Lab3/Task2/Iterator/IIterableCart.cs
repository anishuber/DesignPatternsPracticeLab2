using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Iterator
{
    public interface IIterableCart
    {
        IProductIterator<string> CreateIterator();
    }
}
