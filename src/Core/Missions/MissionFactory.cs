using System.Collections.Generic;

namespace Cahoots.Core
{
    public static class MissionFactory
    {
        public static IEnumerable<IMission> Create()
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
