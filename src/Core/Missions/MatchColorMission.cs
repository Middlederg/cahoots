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

        public override string ToString() => $"{string.Join(" / ", matchColors.Select(x => $"[#{x.Hex}]")) } x{objective}";
    }
}
