namespace Cahoots.Core
{
    public class LowerThanMission : IMission
    {
        private readonly int maximun;

        public LowerThanMission(int maximun)
        {
            this.maximun = maximun;
        }

        public bool CanBeCompleted(CardSet cardSet) => cardSet.AllAreLowerThan(maximun);

        public override string ToString() => $"< {maximun}";
    }
}
