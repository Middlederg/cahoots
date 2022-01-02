using System.Collections.Generic;
using System.Linq;

namespace Cahoots.Core
{
    public class Game
    {
        private readonly List<Card> deck;
        private readonly List<IMission> missionDeck;

        public List<Pile> Piles { get; }
        public List<Card> PlayerHand { get; }
        public List<IMission> AvaliableMissions { get; }

        public Game(GameOptions options)
        {
            this.deck = CardFactory.Create().ToList();
            this.PlayerHand = Enumerable.Range(0, options.HandSize).Select(i => DrawCard()).ToList();
            this.Piles = Enumerable.Range(0, options.PileCount).Select(i => new Pile(DrawCard())).ToList();

            this.missionDeck = MissionFactory.Create().ToList();
            this.AvaliableMissions = Enumerable.Range(0, options.MissionCount).Select(i => DrawMission()).ToList();
        }

        private Card DrawCard()
        {
            var card = deck.First();
            this.deck.Remove(card);
            return card;
        }

        private IMission DrawMission()
        {
            var mission = missionDeck.First();
            this.missionDeck.Remove(mission);
            return mission;
        }

        public void Play(Card card, Pile pile)
        {
            if (PlayerHand.Contains(card))
            {
                if (pile.CanBePlayed(card))
                {
                    pile.Add(card);
                    PlayerHand.Remove(card);
                }
            }
        }

        public bool GameHasEnded()
        {
            foreach (var card in PlayerHand)
            {
                foreach(var pile in Piles)
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
