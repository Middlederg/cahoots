using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public class MatchColorMission : IMission
    {
        private readonly Color[] matchColors;
        private readonly int objective;

        public MatchColorMission(int objective, params Color[] matchColors)
        {
            this.matchColors = matchColors;
            this.objective = objective;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            return cardSet.FromColor(matchColors) == objective;
        }

        public string Description() => $"{string.Join(" / ", matchColors.ToList())} x{objective}";

        public IEnumerable<IDisplayableItem> Display()
        {
            foreach ((Color color, int index) in matchColors.Select((x, index) => (x, index)))
            {
                yield return color;
                if (index < matchColors.Length)
                {
                    yield return TextItem.Or;
                }
            }

            yield return TextItem.Times(objective);
        }
    }
}
