using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public static class CardFactory
    {
        public static IEnumerable<Card> Create()
        {

            var one = CreateOnce();
            var two = CreateOnce();
            var deck = one.Concat(two).ToList();
            return Randomizer.RandomizeList(deck);
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
