using System;
using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public record LogEntry(string Title, LogEntryType Type) { }

    public enum LogEntryType
    {
        CardPlayed,
        MissionAccomplished
    }

    public class Game
    {
        private readonly List<Card> deck;
        public int RemainingCardCount => deck.Count;

        private readonly List<IMission> missionDeck;
        public int RemainingMissionCardCount => missionDeck.Count;

        public List<Pile> Piles { get; }
        public PlayerHand PlayerHand { get; }

        public List<IMission> AvaliableMissions { get; }
        public List<IMission> CompletedMissions { get; private set; }

        public List<LogEntry> Log { get; }
        public string LastMission => Log.LastOrDefault(x => x.Type == LogEntryType.MissionAccomplished)?.Title;

        public Game(GameOptions options)
        {
            deck = CardFactory.Create().ToList();
            PlayerHand = new PlayerHand(Enumerable.Range(0, options.HandSize).Select(i => DrawCard()));
            Piles = Enumerable.Range(0, options.PileCount).Select(i => new Pile(DrawCard())).ToList();

            missionDeck = MissionFactory.Create().ToList();
            AvaliableMissions = Enumerable.Range(0, options.MissionCount).Select(i => DrawMission()).ToList();
            CompletedMissions = new List<IMission>();

            Log = new List<LogEntry>();
        }

        public void AddNewCardToHand()
        {
            if (deck.Any())
            {
                PlayerHand.Add(DrawCard());
            }
        }

        private Card DrawCard()
        {
            var card = deck.First();
            deck.Remove(card);
            return card;
        }

        private IMission DrawMission()
        {
            var mission = missionDeck.First();
            missionDeck.Remove(mission);
            return mission;
        }

        public bool CanBePlayed(Card card, Pile pile) => PlayerHand.Contains(card) && pile.CanBePlayed(card);

        public void Play(Card card, Pile pile)
        {
            pile.Add(card);
            PlayerHand.Remove(card);
            Log.Add(new LogEntry(card.ToString(), LogEntryType.CardPlayed));

            var accomplishableMissions = AvaliableMissions.Where(mission => mission.CanBeCompleted(new CardSet(Piles))).ToList();
            foreach (var mission in accomplishableMissions)
            {
                CompletedMissions.Add(mission);
                AvaliableMissions.Remove(mission);
                AvaliableMissions.Add(DrawMission());
            }

            if (accomplishableMissions.Any())
            {
                Log.Add(new LogEntry(string.Join(", ", accomplishableMissions), LogEntryType.MissionAccomplished));
            }
        }

        public bool GameHasEnded()
        {
            foreach (var card in PlayerHand.Cards)
            {
                foreach (var pile in Piles)
                {
                    if (pile.CanBePlayed(card))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
