namespace Cahoots.Core
{
    public class GreaterThanMission : IMission
    {
        private readonly int minimun;

        public GreaterThanMission(int minimun)
        {
            this.minimun = minimun;
        }

        public bool CanBeCompleted(CardSet cardSet) => cardSet.AllAreGreaterThan(minimun);
    }
}
