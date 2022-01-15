using System.Collections.Generic;
using Cahoots.Core;
using FluentAssertions;
using Xunit;

namespace Cahoots.UnitTests
{
    public class EvenNumberMissionShould
    {
        [Fact]
        public void Be_completed_when_all_cards_are_even()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue2, CardMother.Red4, CardMother.Green4, CardMother.Orange2),
                CardSetMother.Create(CardMother.Blue2, CardMother.Red4, CardMother.Green6, CardMother.Orange2),
                CardSetMother.Create(CardMother.Blue2, CardMother.Red2, CardMother.Green4, CardMother.Orange2)
            };

            var mission = new EvenNumberMission();

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeTrue();
            }
        }

        [Fact]
        public void Not_be_completed_when_some_card_is_odd()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue2, CardMother.Red4, CardMother.Green4, CardMother.Orange1),
                CardSetMother.Create(CardMother.Blue2, CardMother.Red7, CardMother.Green6, CardMother.Orange2),
                CardSetMother.Create(CardMother.Blue2, CardMother.Red3, CardMother.Green3, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green4, CardMother.Orange4),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red3, CardMother.Green4, CardMother.Orange5)
            };

            var mission = new EvenNumberMission();

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeFalse();
            }
        }
    }
}
