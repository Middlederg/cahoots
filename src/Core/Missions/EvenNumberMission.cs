using System.Collections.Generic;

namespace Cahoots.Core
{
    public class EvenNumberMission : IMission
    {
        public bool CanBeCompleted(CardSet cardSet) => cardSet.AllAreEven();

        public string Description() => "All cards are even";

        public IEnumerable<IDisplayableItem> Display() => new List<IDisplayableItem>()
        {
            Icon.Even,
            TextItem.FourTimes,
        };
    }
}
