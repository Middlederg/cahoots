using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public static class LadderExtensions
    {
        public static int Count(IEnumerable<int> numbers)
        {
            int last = numbers.First() - 1;
            int count = 0;
            foreach(int currentNumber in numbers)
            {
                if (currentNumber != last + 1)
                {
                    return count;
                }

                count++;
                last++;
            }
            return count;
        }
    }
}
