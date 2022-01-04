namespace Cahoots.Core
{
    public class GameOptions
    {
        public int HandSize { get; set; }
        public int MissionCount = 4;
        public int PileCount = 4;

        public GameOptions()
        {
            HandSize = 4;
        }
    }
}
