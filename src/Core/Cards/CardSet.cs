using System;
using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public class CardSet
    {
        private readonly IEnumerable<Card> cards;

        public CardSet(IEnumerable<Pile> piles)
        {
            cards = piles.Select(x => x.VisibleCard);
        }

        public int TotalSum(Color color = null) => cards
            .Where(x => color is null || color == x.Color)
            .Sum(x => x.Number);

        public bool AllAreEven() => cards.All(x => x.IsEven);
        public int FromColor(IEnumerable<Color> color) => cards.Count(x => color.Contains(x.Color));

        public int NumberCount => cards.Select(x => x.Number).Distinct().Count();
        public int ColorCount => cards.Select(x => x.Color).Distinct().Count();
        public bool AllAreGreaterThan(int minimun) => cards.All(x => x.Number >= minimun);
        public bool AllAreLowerThan(int maximun) => cards.All(x => x.Number < maximun);
        public bool HasEvenOddAlternance()
        {
            EvenOddStatus? last = null;
            foreach (var card in cards)
            {
                if (card.Status == last)
                {
                    return false;
                }
                last = card.Status;
            }
            return true;
        }

        public int UnorderedLadderCount()
        {
            var numbers = cards.Select(x => x.Number);
            var ascending = numbers.Distinct().OrderBy(x => x);
            int ascendingCount = OrderExtensions.AscendingCount(ascending);
            var descending = numbers.Distinct().OrderBy(x => x);
            int descendingCount = OrderExtensions.DescendingCount(descending);

            return Math.Max(ascendingCount, descendingCount);
        }

        // public int OrderedAscendingLadderCount()
        // {
        //     var numbers = cards.Select(x => x.Number).ToList();
        //     int ascendingCount = OrderExtensions.AscendingCount(numbers);

        //     for (int i = 0; i < numbers.Count; i++)
        //     {
                
        //         OrderExtensions.AscendingCount(numbers.RemoveAt(i));
        //     }
        //     int descendingCount = OrderExtensions.DescendingCount(numbers);

        //     return Math.Max(ascendingCount, descendingCount);
        // }
    }
}
