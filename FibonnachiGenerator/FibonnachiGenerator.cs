using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonnachiGenerator
{
    public class FibonnachiGenerator
    {
        public static IEnumerable<int> GenerateFibbonachiSequance(int count)
        {
            if (count < 1)
                throw new ArgumentException(nameof(count));
            int a = 0;
            int b = 1;
            for (int i = 0; i < count; i++)
            {
                int result = a + b;
                a = b;
                b = result;
                yield return result;
            }
        }
    }
}
