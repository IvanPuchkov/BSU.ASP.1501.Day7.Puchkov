using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearcher
{
    public static class BinarySearcher<T>
    {
        public delegate int Compare(T x, T y);

        public static int Search(T[] collection, T key) => Search(collection, key, (IComparator<T>) null);

        public static int Search(T[] collection, T key, Compare comparer)
        {
            if (comparer==null)
                throw new ArgumentNullException(nameof(comparer));

            return Search(collection, key, new Comparisor<T>(comparer));
        }

        public static int Search(T[] collection, T key, IComparator<T> comparator)
        {
            if (collection==null)
                throw new ArgumentNullException(nameof(collection));
            if (collection.Length==0)
                throw new ArgumentException(nameof(collection));
            int min = 0;
            int max = collection.Length-1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                int comperedValue=0;
                if (comparator != null)
                {
                    comperedValue = comparator.Compare(key, collection[mid]);
                }
                else
                {
                    var enumerable = key as IComparable<T>;
                    if (enumerable!=null)
                        comperedValue = enumerable.CompareTo(collection[mid]);
                    else
                    {
                        dynamic lhs = key;
                        try
                        {
                            comperedValue = lhs - collection[mid];
                        }
                        catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
                        {
                            throw new InvalidOperationException($"Can't compare {typeof(T)}");
                        }
                    }
                }
                if (comperedValue==0)
                {
                    return mid;
                }
                if (comperedValue<0)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}
