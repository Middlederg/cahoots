using System.Collections.Generic;
using Cahoots.Core;
using FluentAssertions;
using Xunit;

namespace Cahoots.UnitTests
{
    public class EvenOddAlternanceMissionShould
    {
        [Fact]
        public void Be_completed_when_cards_have_even_odd_alternance()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue2, CardMother.Red5, CardMother.Green2, CardMother.Orange7),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Orange6),
                CardSetMother.Create(CardMother.Blue2, CardMother.Red1, CardMother.Green4, CardMother.Orange5),
                CardSetMother.Create(CardMother.Blue2, CardMother.Red3, CardMother.Green2, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue5, CardMother.Red6, CardMother.Green1, CardMother.Orange6),
                CardSetMother.Create(CardMother.Blue4, CardMother.Red1, CardMother.Green6, CardMother.Orange7)
            };

            var mission = new EvenOddAlternanceMission();

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeTrue();
            }
        }

        [Fact]
        public void Not_be_completed()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue1, CardMother.Red3, CardMother.Green5, CardMother.Orange7),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Orange7),
                CardSetMother.Create(CardMother.Blue4, CardMother.Red1, CardMother.Green4, CardMother.Orange2),
                CardSetMother.Create(CardMother.Blue5, CardMother.Red3, CardMother.Green5, CardMother.Orange7),
                CardSetMother.Create(CardMother.Blue2, CardMother.Red2, CardMother.Green3, CardMother.Orange5)
            };

            var mission = new EvenOddAlternanceMission();

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeFalse();
            }
        }
    }
}
