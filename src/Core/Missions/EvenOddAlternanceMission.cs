using System.Collections.Generic;

namespace Cahoots.Core
{
    public class EvenOddAlternanceMission : IMission
    {
        public bool CanBeCompleted(CardSet cardSet) => cardSet.HasEvenOddAlternance();

        public string Description() => "Even - odd alternance";

        public IEnumerable<IDisplayableItem> Display() => new List<IDisplayableItem>()
        {
            Icon.Even,
            TextItem.Separator,
            Icon.Odd,
            TextItem.Separator,
            Icon.Even,
            TextItem.Separator,
            Icon.Odd,
        };
    }
}
