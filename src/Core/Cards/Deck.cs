using System;
using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public static class Deck
    {
        public const int DefaultSize = 56;

        public static IEnumerable<Card> Create(int maxSize)
        {
            var deck = CreateOnce().Concat(CreateOnce()).ToList();
            int size = Math.Min(maxSize, deck.Count);
            return Randomizer.RandomizeList(deck).Take(size);
        }

        private static IEnumerable<Card> CreateOnce()
        {
            return Color.Colors.SelectMany(color =>
            {
                return Enumerable.Range(1, 7).Select(number => new Card(number, color));
            });
        }
    }
}
