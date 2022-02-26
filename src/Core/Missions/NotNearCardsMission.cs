using System.Collections.Generic;

namespace Cahoots.Core
{
    public class NotNearCardsMission : IMission
    {
        private readonly Color color;

        public NotNearCardsMission(Color color)
        {
            this.color = color;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            if (cardSet.FromColor(color) != 2)
            {
                return false;
            }

            var lastColor = cardSet.ColorAt(0);
            for(int i = 0; i < cardSet.Count - 1; i++)
            {
                if (cardSet.ColorAt(i) == color && cardSet.ColorAt(i + 1) == color)
                {
                    return false;
                }
            }

            return true;
        }

        public string Description() => $"There are 2 separate {color} piles";


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
