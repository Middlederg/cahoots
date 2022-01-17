namespace Cahoots.Core
{
    public class NearCardsMission : IMission
    {
        private readonly int objective;
        private readonly Color color;

        public NearCardsMission(int objective, Color color)
        {
            this.objective = objective;
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
    }
}
