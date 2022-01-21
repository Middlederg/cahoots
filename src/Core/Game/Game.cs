using System;
using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
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

        public Log Log { get; }

        public Game(GameOptions options)
        {
            deck = Deck.Create(options.DeckSize).ToList();
            var handCards = Enumerable.Range(1, options.HandSize).Select(i => DrawCard()).ToList();
            PlayerHand = new PlayerHand(handCards);

            Piles = Enumerable.Range(0, GameOptions.PileCount).Select(i => new Pile(DrawCard())).ToList();

            missionDeck = MissionDeck.Create(options.MissionDeckSize).ToList();
            AvaliableMissions = Enumerable.Range(1, GameOptions.AvaliableMissionCount).Select(i => DrawMission()).ToList();
            CompletedMissions = new List<IMission>();

            Log = new Log();
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
            Log.AddCard(card);

            var accomplishableMissions = AvaliableMissions.Where(mission => mission.CanBeCompleted(new CardSet(Piles))).ToList();
            foreach (var mission in accomplishableMissions)
            {
                CompletedMissions.Add(mission);
                AvaliableMissions.Remove(mission);

                if (missionDeck.Any())
                {
                    AvaliableMissions.Add(DrawMission());
                }
            }

            if (accomplishableMissions.Any())
            {
                Log.AddMissions(accomplishableMissions);
            }
        }

        public bool GameHasEnded()
        {
            if (!AvaliableMissions.Any())
            {
                return true;
            }

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
