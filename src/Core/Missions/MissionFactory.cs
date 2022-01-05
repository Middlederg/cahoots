using System;
using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public static class MissionFactory
    {
        public const int DefaultMissionSize = 54;

        public static IEnumerable<IMission> Create(int? maxSize)
        {
            var deck = GetAllMissions().ToList();
            int size = maxSize.HasValue ? Math.Min(maxSize.Value, deck.Count) : deck.Count;
            return Randomizer.RandomizeList(deck).Take(size);
        }

        public static IEnumerable<IMission> GetAllMissions()
        {
            yield return new EvenNumberMission();
            yield return new SimpleMission();
            yield return new EvenOddAlternanceMission();
            yield return new MatchColorMission(4, Color.Blue, Color.Green);
            yield return new MatchColorMission(3, Color.Red);
            yield return new SumMission(20);
            yield return new SumMission(11, Color.Orange);
            yield return new SumMission(15);
            yield return new UnrepeatedMission(numbers: true, colors: true);
            yield return new UnrepeatedMission(numbers: true, colors: false);
            yield return new UnrepeatedMission(numbers: false, colors: true);
        }
    }
}
