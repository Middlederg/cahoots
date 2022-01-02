namespace Cahoots.Core
{
    public class EvenOddAlternanceMission : IMission
    {
        public bool CanBeCompleted(CardSet cardSet) => cardSet.HasEvenOddAlternance();
    }
}
