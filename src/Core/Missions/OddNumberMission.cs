namespace Cahoots.Core
{
    public class OddNumberMission : IMission
    {
        public bool CanBeCompleted(CardSet cardSet) => cardSet.AllAreOdd();

        public override string ToString() => "Odd x4";
    }
}
