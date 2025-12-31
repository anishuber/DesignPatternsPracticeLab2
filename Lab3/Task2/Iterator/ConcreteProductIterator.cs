using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Iterator
{
    public class ConcreteProductIterator : IProductIterator<string>
    {
        private Cart _cart;
        private int _index;

        public ConcreteProductIterator(Cart cart)
        {
            ArgumentNullException.ThrowIfNull(nameof(cart));
            _cart = cart;
        }

        public void GetNext()
        {
            _index++;
        }

        public bool HasMore()
        {
            return _index < _cart.Products.Count;
        }

        public string Current()
        {
            return _cart.Products[_index];
        }
    }
}
