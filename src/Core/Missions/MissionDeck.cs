using System;
using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public static class MissionDeck
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
            yield return new SumMission(2, Color.Orange);
            yield return new SumMission(3, Color.Blue);
            yield return new SumMission(4, Color.Red);
            yield return new SumMission(6, Color.Green);
            yield return new SumMission(7, Color.Green);
            yield return new SumMission(9, Color.Blue);
            yield return new SumMission(10, Color.Red);
            yield return new SumMission(11, Color.Orange);
            yield return new SumMission(10);
            yield return new SumMission(20);
            yield return new SumMission(15);
            yield return new SumMission(18);
            yield return new UnrepeatedMission(numbers: false, colors: true);
            yield return new UnrepeatedMission(numbers: true, colors: false);
            yield return new UnrepeatedMission(numbers: true, colors: true);
            yield return new NotNearCardsMission(Color.Red);
            yield return new NotNearCardsMission(Color.Green);
            yield return new NotNearCardsMission(Color.Blue);
            yield return new NotNearCardsMission(Color.Orange);
            yield return new DoubleSumMission(Color.Red, Color.Blue);
            yield return new DoubleSumMission(Color.Green, Color.Red);
            yield return new DoubleSumMission(Color.Blue, Color.Green);
            yield return new DoubleSumMission(Color.Blue, Color.Orange);
            yield return new DoubleSumMission(Color.Green, Color.Orange);
            yield return new DoubleSumMission(Color.Orange, Color.Red);
            yield return new ColorAlternanceMission(Color.Green);
            yield return new ColorAlternanceMission(Color.Blue);
            yield return new ColorAlternanceMission(Color.Orange);
            yield return new NearCardsMission(Color.Orange);
            yield return new NearCardsMission(Color.Green);
            yield return new NearCardsMission(Color.Red);
            yield return new NearCardsMission(Color.Blue);
            yield return new NearCardsMission(Color.Red);
            yield return new OrderedLadderMission(3);
            yield return new UnorderedLadderMission(4);
            yield return new LowerThanMission(4);
            yield return new GreaterThanMission(4);
            yield return new SameSumMission(Color.Red, Color.Orange);
            yield return new SameSumMission(Color.Green, Color.Blue);
            yield return new SameSumMission(Color.Blue, Color.Red);
            yield return new SameSumMission(Color.Green, Color.Red);
            yield return new SameSumMission(Color.Orange, Color.Blue);
            yield return new SameSumMission(Color.Orange, Color.Green);
            yield return new MatchColorMission(3, Color.Red);
            yield return new MatchColorMission(3, Color.Orange);
            yield return new MatchColorMission(3, Color.Blue);
            yield return new MatchColorMission(4, Color.Green, Color.Orange);
            yield return new MatchColorMission(4, Color.Red, Color.Blue);
            yield return new MatchColorMission(4, Color.Red, Color.Green);
            yield return new EvenNumberMission();
            yield return new OddNumberMission();
            yield return new EvenOddAlternanceMission();
        }
    }
}
