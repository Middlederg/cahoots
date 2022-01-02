namespace Cahoots.Core
{
    public class SumMission : IMission
    {
        private int objective;
        private Color color;

        public SumMission(int objective, Color color = null)
        {
            this.objective = objective;
            this.color = color;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            return cardSet.TotalSum(objective, color) == objective;
        }
    }
}
