using System.Collections.Generic;
using Cahoots.Core;
using FluentAssertions;
using Xunit;

namespace Cahoots.UnitTests
{
    public class ColorAlternanceMissionShould
    {
        [Fact]
        public void Be_completed()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Red3),
                CardSetMother.Create(CardMother.Red3, CardMother.Orange1, CardMother.Red4, CardMother.Orange5),
                CardSetMother.Create(CardMother.Red3, CardMother.Orange1, CardMother.Red4, CardMother.Blue1),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Red7)
            };

            var mission = new ColorAlternanceMission(2, Color.Red);

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
                CardSetMother.Create(CardMother.Blue1, CardMother.Red1, CardMother.Green1, CardMother.Orange1),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green4, CardMother.Green3),
                CardSetMother.Create(CardMother.Blue2, CardMother.Red5, CardMother.Red5, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue3, CardMother.Red4, CardMother.Orange1, CardMother.Orange1),
                CardSetMother.Create(CardMother.Red2, CardMother.Red4, CardMother.Blue3, CardMother.Blue5),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red7, CardMother.Red2, CardMother.Orange6),
                CardSetMother.Create(CardMother.Blue1, CardMother.Blue3, CardMother.Blue2, CardMother.Blue4),
                CardSetMother.Create(CardMother.Blue1, CardMother.Blue2, CardMother.Red5, CardMother.Blue3),
                CardSetMother.Create(CardMother.Blue6, CardMother.Blue2, CardMother.Blue5, CardMother.Red5),
                CardSetMother.Create(CardMother.Blue6, CardMother.Red3, CardMother.Blue5, CardMother.Blue4),
                CardSetMother.Create(CardMother.Red4, CardMother.Red3, CardMother.Blue5, CardMother.Blue4),
                CardSetMother.Create(CardMother.Red4, CardMother.Green2, CardMother.Blue5, CardMother.Red4)
            };

            var mission = new ColorAlternanceMission(2, Color.Red);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeFalse();
            }
        }
    }
}
