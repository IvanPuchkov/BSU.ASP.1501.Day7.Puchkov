using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearcher
{
    public class Comparisor<T> : IComparator<T>
    {
        private readonly BinarySearcher<T>.Compare _compare;

        public Comparisor(BinarySearcher<T>.Compare comparer)
        {
            _compare = comparer;
        }

        public int Compare(T x, T y) => _compare(x, y);
    }
}
