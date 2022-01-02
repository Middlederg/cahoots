using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public static class OrderExtensions
    {
        public static int AscendingCount(IEnumerable<int> numbers)
        {
            int last = numbers.First() - 1;
            int count = 0;
            foreach(int number in numbers)
            {
                int expected = last + 1;
                if (number == expected)
                {
                    count++;
                }
            }
            return count;
        }
        public static int DescendingCount(IEnumerable<int> numbers)
        {
            numbers = numbers.Distinct().OrderByDescending(x => x);
            int last = numbers.First() + 1;
            int count = 0;
            foreach(int number in numbers)
            {
                int expected = last - 1;
                if (number == expected)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
