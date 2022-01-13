using System.Collections.Generic;
using Cahoots.Core;
using FluentAssertions;
using Xunit;

namespace Cahoots.UnitTests
{
    public class LowerThanMissionShould
    {
        [Fact]
        public void Be_completed_when_all_cards_are_less_than_5()
        {
            var setCollection = new List<CardSet>() 
            {
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Orange4),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue2, CardMother.Red1, CardMother.Green4, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue3, CardMother.Red4, CardMother.Green1, CardMother.Orange4),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red1, CardMother.Green2, CardMother.Orange2),
                CardSetMother.Create(CardMother.Blue2, CardMother.Red2, CardMother.Green2, CardMother.Orange2),
            };

            var mission = new LowerThanMission(maximun: 5);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeTrue();
            }
        }

        [Fact]
        public void Not_be_completed_when_any_cards_is_greater_or_equal_5()
        {
            var setCollection = new List<CardSet>() 
            {
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Orange5),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green7, CardMother.Orange5),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red5, CardMother.Green4, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue3, CardMother.Red4, CardMother.Green7, CardMother.Orange6),
                CardSetMother.Create(CardMother.Blue6, CardMother.Red1, CardMother.Green7, CardMother.Orange2),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red5, CardMother.Green6, CardMother.Orange5),
            };

            var mission = new LowerThanMission(maximun: 5);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeFalse();
            }
        }
    }
}
