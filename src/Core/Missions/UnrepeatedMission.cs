using System;

namespace Cahoots.Core
{
    public class UnrepeatedMission : IMission
    {
        private readonly bool numbers;
        private readonly bool colors;

        public UnrepeatedMission(bool numbers, bool colors)
        {
            this.numbers = numbers;
            this.colors = colors;
        }

        public bool CanBeCompleted(CardSet cardSet)
        {
            if (numbers || cardSet.NumberCount != 4)
            {
                return false;
            }
            if (colors || cardSet.ColorCount != 4)
            {
                return false;
            }
            return true;
        }
    }
}
