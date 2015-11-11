using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearcher
{
    public interface IComparator<T>
    {
        int Compare(T x, T y);
    }
}
