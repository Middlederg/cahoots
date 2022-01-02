namespace Cahoots.Core
{
    public class EvenNumberMission : IMission
    {
        public bool CanBeCompleted(CardSet cardSet) => cardSet.AllAreEven();
    }
}
