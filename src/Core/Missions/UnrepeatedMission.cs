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
            if (numbers && cardSet.NumberCount != cardSet.Count)
            {
                return false;
            }
            if (colors && cardSet.ColorCount != cardSet.Count)
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
                if (colors)
                {
                    yield return "all colors";
                }
            }
        }
    }
}
