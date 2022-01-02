using System;
using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public enum EvenOddStatus
    {
        Even,
        Odd
    }
    public record Card(int Number, Color Color)
    {
        public bool IsEven => Number % 2 == 0;
        public EvenOddStatus Status => IsEven ? EvenOddStatus.Even : EvenOddStatus.Odd;
    }

    public record Color
    {
        public string Hex { get; }
        private Color(string hex)
        {
            Hex = hex;
        }
        public static Color Red => new Color("D6234A");
        public static Color Orange => new Color("FF6600");
        public static Color Green => new Color("006400");
        public static Color Blue => new Color("2D7AC0");

        public static IEnumerable<Color> Colors
        {
            get
            {
                yield return Red;
                yield return Orange;
                yield return Green;
                yield return Blue;
            }
        }
    }

    public static class CardFactory
    {
        public static IEnumerable<Card> Create()
        {
            return Color.Colors.SelectMany(color =>
            {
                return Enumerable.Range(1, 7).Select(number => new Card(number, color));
            });
        }
    }

    public class CardSet
    {
        private readonly IEnumerable<Card> cards;

        public CardSet(IEnumerable<Card> cards)
        {
            if (cards is null || cards.Count() != 4)
            {
                throw new ArgumentException($"A cardset must be formed by 4 cards. {cards.Count()} were found");
            }
            this.cards = cards;
        }

        public int TotalSum(int sum, Color color = null) => cards
            .Where(x => color is null || color == x.Color)
            .Sum(x => x.Number);

        public bool AllAreEven() => cards.All(x => x.IsEven);
        public int FromColor(IEnumerable<Color> color) => cards.Count(x => color.Contains(x.Color));

        public int NumberCount => cards.Select(x => x.Number).Distinct().Count();
        public int ColorCount => cards.Select(x => x.Color).Distinct().Count();
        public bool AllAreGreaterThan(int minimun) => cards.All(x => x.Number > minimun);
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

        public int OrderedAscendingLadderCount()
        {
            var numbers = cards.Select(x => x.Number).ToList();
            int ascendingCount = OrderExtensions.AscendingCount(numbers);

            for (int i = 0; i < numbers.Count; i++)
            {
                
            OrderExtensions.AscendingCount(numbers.RemoveAt(i));
            }
            int descendingCount = OrderExtensions.DescendingCount(numbers);

            return Math.Max(ascendingCount, descendingCount);
        }
    }

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

    public interface IMission
    {
        bool CanBeCompleted(CardSet cardSet);
    }

    public class EvenOddAlternanceMission : IMission
    {
        public bool CanBeCompleted(CardSet cardSet) => cardSet.HasEvenOddAlternance();
    }
}
