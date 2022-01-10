using System.Linq;
using Cahoots.Core;

namespace Cahoots.UnitTests
{
    public static class CardSetMother
    {
        public static CardSet Create(params Card[] cards) => new CardSet(cards.Select(x => new Pile(x)));
    }
}