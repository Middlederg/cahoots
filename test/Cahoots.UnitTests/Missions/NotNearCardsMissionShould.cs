using System.Collections.Generic;
using Cahoots.Core;
using FluentAssertions;
using Xunit;

namespace Cahoots.UnitTests
{
    public class NotNearCardsMissionShould
    {
        [Fact]
        public void Be_completed()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Red4),
                CardSetMother.Create(CardMother.Red1, CardMother.Blue3, CardMother.Red2, CardMother.Orange2),
                CardSetMother.Create(CardMother.Red7, CardMother.Blue4, CardMother.Orange3, CardMother.Red4),
                CardSetMother.Create(CardMother.Blue3, CardMother.Red3, CardMother.Green5, CardMother.Red6),
                CardSetMother.Create(CardMother.Red4, CardMother.Green3, CardMother.Orange2, CardMother.Red4),
                CardSetMother.Create(CardMother.Red7, CardMother.Orange2, CardMother.Red5, CardMother.Orange2)
            };

            var mission = new NotNearCardsMission(Color.Red);

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
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Orange2),
                CardSetMother.Create(CardMother.Red1, CardMother.Red5, CardMother.Red2, CardMother.Orange2),
                CardSetMother.Create(CardMother.Red7, CardMother.Blue4, CardMother.Red6, CardMother.Red4),
                CardSetMother.Create(CardMother.Red3, CardMother.Red3, CardMother.Green5, CardMother.Red6),
                CardSetMother.Create(CardMother.Red3, CardMother.Red4, CardMother.Red1, CardMother.Red4),
                CardSetMother.Create(CardMother.Green3, CardMother.Orange2, CardMother.Green3, CardMother.Orange2),
                CardSetMother.Create(CardMother.Red5, CardMother.Orange2, CardMother.Green3, CardMother.Orange2),
                CardSetMother.Create(CardMother.Red5, CardMother.Red3, CardMother.Green3, CardMother.Orange2),
                CardSetMother.Create(CardMother.Red5, CardMother.Red3, CardMother.Green3, CardMother.Red6)
            };

            var mission = new NotNearCardsMission(Color.Red);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeFalse();
            }
        }
    }
}
