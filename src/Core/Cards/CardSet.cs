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
        public bool AllAreOdd() => cards.All(x => !x.IsEven);
        public int FromColor(params Color[] colors) => cards.Count(x => colors.Contains(x.Color));
        public bool Includes(Color color) => cards.Any(x => color == x.Color);

        public int Count => cards.Count();
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
            var numbers = cards
                .Select(x => x.Number)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var options = GetLadderCountOptions(numbers);
            return options.Max();
        }

        public int OrderedLadderCount()
        {
            var numbers = cards
                .Select(x => x.Number)
                .ToList();

            var options = GetLadderCountOptions(numbers);
            return options.Max();
        }

        private IEnumerable<int> GetLadderCountOptions(List<int> numbers)
        {
                while (numbers.Any())
                {
                    yield return LadderExtensions.Count(numbers);
                    numbers = numbers.Skip(1).ToList();
                }
            
        }

        public Color ColorAt(int index)
        {
            return cards.ElementAt(index).Color;
        }
    }
}
