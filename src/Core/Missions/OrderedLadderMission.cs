namespace Cahoots.Core
{
    public class OrderedLadderMission : IMission
    {
        private readonly int objective;

        public OrderedLadderMission(int objective)
        {
            this.objective = objective;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            return cardSet.OrderedLadderCount() >= objective;
        }
    }
}
