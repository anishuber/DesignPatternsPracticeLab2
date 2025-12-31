using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Iterator
{
    public class Cart : IIterableCart
    {
        private List<string> _products = [];

        public List<string> Products { get { return _products; } }

        public void Push(string product)
        {
            _products.Add(product);
        }

        public string Pop()
        {
            var removed = _products[^1];
            _products.Remove(removed);
            return removed;
        }

        public IProductIterator<string> CreateIterator()
        {
            return new ConcreteProductIterator(this);
        }
    }
}
