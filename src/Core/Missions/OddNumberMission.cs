using System.Collections.Generic;

namespace Cahoots.Core
{
    public class OddNumberMission : IMission
    {
        public bool CanBeCompleted(CardSet cardSet) => cardSet.AllAreOdd();

        public string Description() => "All cards are even";


        public IEnumerable<IDisplayableItem> Display() => new List<IDisplayableItem>()
        {
            Icon.Odd,
            TextItem.FourTimes,
        };
    }
}
