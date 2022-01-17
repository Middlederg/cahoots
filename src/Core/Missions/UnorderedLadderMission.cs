namespace Cahoots.Core
{
    public class UnorderedLadderMission : IMission
    {
        private readonly int objective;

        public UnorderedLadderMission(int objective)
        {
            this.objective = objective;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            return cardSet.UnorderedLadderCount() >= objective;
        }
    }
}
