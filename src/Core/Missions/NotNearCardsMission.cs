namespace Cahoots.Core
{
    public class NotNearCardsMission : IMission
    {
        private readonly int objective;
        private readonly Color color;

        public NotNearCardsMission(int objective, Color color)
        {
            this.objective = objective;
            this.color = color;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            if (cardSet.FromColor(color) != 2)
            {
                return false;
            }

            var lastColor = cardSet.ColorAt(0);
            for(int i = 0; i < cardSet.Count - 1; i++)
            {
                if (cardSet.ColorAt(i) == color && cardSet.ColorAt(i + 1) == color)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
