namespace Cahoots.Core
{
    public class GameOptions
    {
        public int HandSize { get; set; }
        public int MissionCount { get; set; }
        public int PileCount { get; set; }

        public GameOptions()
        {
            HandSize = 4;
            MissionCount = 4;
            PileCount = 4;
        }
    }
}
