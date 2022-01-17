namespace Cahoots.Core
{
    public class SumMission : IMission
    {
        private readonly int objective;
        private readonly Color color;

        public SumMission(int objective, Color color = null)
        {
            this.objective = objective;
            this.color = color;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            return cardSet.TotalSum(color) == objective;
        }

        public override string ToString()
        {
            if (color is null)
            {
                return $"Sum = {objective}";
            }
            return $"Sum {color} = {objective}";
        }
    }
}
