using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public class SameSumMission : IMission
    {
        private readonly IEnumerable<Color> colors;

        public SameSumMission(params Color[] colors)
        {
            this.colors = colors;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            foreach (var color in colors)
            {
                if (!cardSet.Includes(color)) 
                {
                    return false;
                }
            }

            var sumCollection = SumCollection(cardSet);
            return sumCollection.All(x => x == sumCollection.First());
        }

        private IEnumerable<int> SumCollection(CardSet cardSet)
        {
            foreach (var color in colors)
            {
                yield return cardSet.TotalSum(color);
            }
        }


        public override string ToString() => string.Join(" = ", colors);

    }
}
