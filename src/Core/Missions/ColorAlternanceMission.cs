using System.Collections.Generic;

namespace Cahoots.Core
{
    public class ColorAlternanceMission : IMission
    {
        private readonly Color color;

        public ColorAlternanceMission(Color color)
        {
            this.color = color;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            if (cardSet.ColorAt(0) == color && cardSet.ColorAt(2) == color)
            {
                return true;
            }

            if (cardSet.ColorAt(1) == color && cardSet.ColorAt(3) == color)
            {
                return true;
            }

            return false;
        }

        public string Description() => $"Alternating piles are {color}";

        public IEnumerable<IDisplayableItem> Display() => new List<IDisplayableItem>()
        {
            color,
            TextItem.Separator,
            Color.Any,
            TextItem.Separator,
            Color.Any,
            TextItem.Separator,
            color,
        };
    }
}
