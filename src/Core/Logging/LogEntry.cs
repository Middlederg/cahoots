using System;
using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public class LogEntry
    {
        public LogEntryType Type { get; }
        public IEnumerable<string> Messages { get; }

        public static LogEntry CardPlayed(Card card) => new(LogEntryType.CardPlayed, card.ToString());
        public static LogEntry MissionAccomplished(IEnumerable<IMission> missions) => new(LogEntryType.MissionAccomplished, missions.Select(x => x.ToString()).ToArray());
        private LogEntry(LogEntryType type, params string[] messages)
        {
            Type = type;
            Messages = messages;
        }

        public string Title => string.Join(", ", Messages);
        private int MessageCount => Messages.Count();

        public override string ToString()
        {
            switch (Type)
            {
                case LogEntryType.CardPlayed: return $"Card played: {Title}";
                case LogEntryType.MissionAccomplished:
                    if (Messages.Count() == 1)
                    {
                        return $"Mission accomplished: {Title}";
                    }
                    return $"{MessageCount} missions accomplished: {Title}";
            }
            throw new NotImplementedException();
        }
    }
}
