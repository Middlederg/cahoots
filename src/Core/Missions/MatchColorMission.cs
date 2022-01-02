using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public class MatchColorMission : IMission
    {
        private IEnumerable<Color> matchColors;
        private int objective;

        public MatchColorMission(int objective, params Color[] matchColors)
        {
            this.matchColors = matchColors.ToList();
            this.objective = objective;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            return cardSet.FromColor(matchColors) == objective;
        }
    }
}
