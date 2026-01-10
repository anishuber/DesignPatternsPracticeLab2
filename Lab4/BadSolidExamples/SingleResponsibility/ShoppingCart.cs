using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BadSolidExamples.SingleResponsibility
{
    // This cart is responsible both for storing the products
    // and iterating over them. Violates single responsibility
    // principle: iteration and storing logic not decoupled
    public class ShoppingCart
    {
        private readonly List<string> _products = [];
        private int _index;

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

        public void GetNext()
        {
            _index++;
        }

        public bool HasMore()
        {
            return _index < Products.Count;
        }

        public string Current()
        {
            return Products[_index];
        }
    }
}
