using System.Collections.Generic;

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

        public string Description() => $"Sum of {simple} x 2 = Sum of {twice}";

        public IEnumerable<IDisplayableItem> Display() => new List<IDisplayableItem>()
        {
            Icon.Sum,
            simple,
            TextItem.Twice,
            TextItem.Equal,
            twice,
        };
    }
}
