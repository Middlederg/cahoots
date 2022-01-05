using System;
using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public class PlayerHand
    {
        public const int MinSize = 2;
        public const int MaxSize = 8;

        private readonly List<PlayerHandCard> cards;
        public List<Card> Cards => cards.OrderBy(x => x.Position).Select(x => x.Card).ToList();

        public PlayerHand(IEnumerable<Card> cards)
        {
            if (cards.Count() < MinSize || cards.Count() > MaxSize)
            {
                throw new ArgumentException($"Hand size must be between {MinSize} and {MaxSize}");
            }

            this.cards = cards.Select((card, index) => new PlayerHandCard(index, card)).ToList();
        }

        public bool Contains(Card card) => Cards.Contains(card);

        internal void Add(Card card)
        {
            var position = SearchMissingPosition();
            cards.Add(new PlayerHandCard(position, card));
        }

        private int SearchMissingPosition()
        {
            foreach (int number in Enumerable.Range(0, 4))
            {
                if (!cards.Any(x => x.Position == number))
                {
                    return number;
                }
            }
            return cards.Max(x => x.Position) + 1;
        }

        internal void Remove(Card card)
        {
            cards.RemoveAll(x => x.Card == card);
        }
    }
}
