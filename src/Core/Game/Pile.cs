using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public class Pile
    {
        private readonly List<Card> cards;
        private Card VisibleCard => cards.Last();
        private int TotalCount => cards.Count;

        public Pile(Card card)
        {
            this.cards = new List<Card>() { card };
        }
        public void Add(Card card) => cards.Add(card);

        public bool CanBePlayed(Card card) => VisibleCard.Color == card.Color || VisibleCard.Number == card.Number;
    }
}
