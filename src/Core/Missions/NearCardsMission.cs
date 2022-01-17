namespace Cahoots.Core
{
    public class NearCardsMission : IMission
    {
        private readonly Color color;

        public NearCardsMission(Color color)
        {
            this.color = color;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            if (cardSet.ColorAt(0) == color && cardSet.ColorAt(1) == color && cardSet.ColorAt(2) != color)
            {
                return true;
            }

             if (cardSet.ColorAt(2) == color && cardSet.ColorAt(3) == color && cardSet.ColorAt(1) != color)
            {
                return true;
            }

            if (cardSet.ColorAt(1) == color && cardSet.ColorAt(2) == color && cardSet.FromColor(color) == 2)
            {
                return true;
            }

            return false;
        }

        public override string ToString() => $"{color} {color} {Color.White} {Color.White}";
    }
}
