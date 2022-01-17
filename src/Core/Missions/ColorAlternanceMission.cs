namespace Cahoots.Core
{
    public class ColorAlternanceMission : IMission
    {
        private readonly int objective;
        private readonly Color color;

        public ColorAlternanceMission(int objective, Color color)
        {
            this.objective = objective;
            this.color = color;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            if (cardSet.ColorAt(0) == color && cardSet.ColorAt(2) == color)
            {
                return true;
            }

            if (cardSet.ColorAt(1) == color && cardSet.ColorAt(3) == color)
            {
                return true;
            }

            return false;
        }

        public override string ToString() => $"{color} {Color.White} {color} {Color.White}";
        
    }
}
