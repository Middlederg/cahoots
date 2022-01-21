using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cahoots.Core
{
    public class GameOptions : IValidatableObject
    {
        [Range(PlayerHand.MinSize, PlayerHand.MaxSize)]
        public int HandSize { get; set; }

        [Range(PlayerHand.MaxSize + PileCount, Deck.DefaultSize)]
        public int DeckSize { get; set; }

        [Range(AvaliableMissionCount, MissionDeck.DefaultMissionSize)]
        public int MissionDeckSize { get; set; }

        public const int AvaliableMissionCount = 4;
        public const int PileCount = 4;

        public GameOptions()
        {
            HandSize = 5;
            DeckSize = 56;
            MissionDeckSize = 54;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HandSize > DeckSize)
            {
                yield return new ValidationResult("Hand size can not be greater than deck size", new[] { nameof(HandSize), nameof(DeckSize) });
            }
        }

        public Dictionary<string, object> CreateParameters()
        {
            return new Dictionary<string, object>()
            {
                { nameof(HandSize), HandSize },
                { nameof(DeckSize), DeckSize },
                { nameof(MissionDeckSize), MissionDeckSize },
            };
        }
    }
}
