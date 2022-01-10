using System;
using System.Collections.Generic;
using System.Linq;

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
            if (numbers && cardSet.NumberCount != 4)
            {
                return false;
            }
            if (colors && cardSet.ColorCount != 4)
            {
                return false;
            }
            return true;
        }


        public override string ToString()
        {
            string result = string.Join(" + ", GetTexts());
            return result;

            IEnumerable<string> GetTexts()
            {
                if (numbers)
                {
                    yield return "all numbers";
                }
                if (numbers)
                {
                    yield return "all colors";
                }
            }
        }
    }
}
