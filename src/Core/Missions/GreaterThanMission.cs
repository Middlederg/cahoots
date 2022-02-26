using System.Collections.Generic;

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

        public IEnumerable<IDisplayableItem> Display() => new List<IDisplayableItem>()
        {
            TextItem.GreaterThan,
            new TextItem(minimun.ToString()),
        };

        public string Description() => $"> {minimun}";
    }
}
