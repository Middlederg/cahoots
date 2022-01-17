namespace Cahoots.Core
{
    public class DoubleSumMission : IMission
    {
        private readonly Color simple;
        private readonly Color twice;

        public DoubleSumMission(Color simple, Color twice)
        {
            this.simple = simple;
            this.twice = twice;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            if (!cardSet.Includes(simple)) return false;
            if (!cardSet.Includes(twice)) return false;

            int simpleTotal = cardSet.TotalSum(simple);
            int twiceTotal = cardSet.TotalSum(twice);
            return simpleTotal * 2  == twiceTotal;
        }

        public override string ToString() => $"{simple} x2 = {twice}";
    }
}
