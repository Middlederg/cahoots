using System.Collections.Generic;

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

        public string Description() => $"< {maximun}";

        public IEnumerable<IDisplayableItem> Display() => new List<IDisplayableItem>()
        {
            TextItem.GreaterThan,
            new TextItem(maximun.ToString()),
        };
    }
}
