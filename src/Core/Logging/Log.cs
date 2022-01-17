using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cahoots.Core
{
    public class Log
    {
        private readonly List<LogEntry> entries;
        public void AddCard(Card card) => entries.Add(LogEntry.CardPlayed(card));
        public void AddMissions(IEnumerable<IMission> missions) => entries.Add(LogEntry.MissionAccomplished(missions));

        public Log()
        {
            entries = new List<LogEntry>();
        }

        public string LastMission => entries.LastOrDefault(x => x.Type == LogEntryType.MissionAccomplished)?.Title;

        public int AccomplishedMissions => entries.Count(x => x.Type == LogEntryType.MissionAccomplished);
        public string AccomplishedMissionsCount => $"{AccomplishedMissions} mission{(AccomplishedMissions == 1 ? "" : "s")} accomplished";

        public int PlayedCards => entries.Count(x => x.Type == LogEntryType.CardPlayed);
        public string PlayedCardsCount => $"{PlayedCards} card{(PlayedCards == 1 ? "" : "s")} played";
    }
}
