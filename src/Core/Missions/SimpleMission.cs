namespace Cahoots.Core
{
    public class SimpleMission : IMission
    {
        public bool CanBeCompleted(CardSet cardSet) => true;

        public override string ToString() => nameof(SimpleMission);
    }
}
