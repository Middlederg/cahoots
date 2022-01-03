namespace Cahoots.Core
{
    public class PlayerHandCard
    {
        public int Position { get; }
        public Card Card { get; private set; }

        public PlayerHandCard(int position, Card card)
        {
            Position = position;
            Card = card;
        }
    }
}
