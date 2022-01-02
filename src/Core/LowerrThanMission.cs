namespace Cahoots.Core
{
    public class LowerrThanMission : IMission
    {
        private readonly int maximun;

        public LowerThanMission(int maximun)
        {
            this.minimun = maximun;
        }

        public bool CanBeCompleted(CardSet cardSet) => cardSet.AllAreLowerThan(minimun);
    }
}
