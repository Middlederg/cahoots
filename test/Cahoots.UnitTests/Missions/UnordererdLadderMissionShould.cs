using System.Collections.Generic;
using Cahoots.Core;
using FluentAssertions;
using Xunit;

namespace Cahoots.UnitTests
{
    public class UnordererdLadderMissionShould
    {
        [Fact]
        public void Be_completed()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Orange4),
                CardSetMother.Create(CardMother.Blue2, CardMother.Red4, CardMother.Green3, CardMother.Orange5),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red5, CardMother.Green4, CardMother.Orange6),
                CardSetMother.Create(CardMother.Blue3, CardMother.Red4, CardMother.Green5, CardMother.Orange2),
                CardSetMother.Create(CardMother.Blue5, CardMother.Red2, CardMother.Green4, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red6, CardMother.Green5, CardMother.Orange4),
                CardSetMother.Create(CardMother.Blue4, CardMother.Red5, CardMother.Green6, CardMother.Orange7),
            };

            var mission = new UnorderedLadderMission(4);

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
                CardSetMother.Create(CardMother.Blue1, CardMother.Red1, CardMother.Green1, CardMother.Red2),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Green3),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red5, CardMother.Red5, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue3, CardMother.Red4, CardMother.Orange1, CardMother.Orange1),
                CardSetMother.Create(CardMother.Blue6, CardMother.Blue2, CardMother.Blue3, CardMother.Blue6),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red7, CardMother.Red2, CardMother.Orange6),
                CardSetMother.Create(CardMother.Blue1, CardMother.Blue2, CardMother.Blue3, CardMother.Blue5),
                CardSetMother.Create(CardMother.Blue1, CardMother.Blue2, CardMother.Blue3, CardMother.Blue7),
                CardSetMother.Create(CardMother.Blue6, CardMother.Blue2, CardMother.Blue5, CardMother.Blue4)
            };

            var mission = new UnorderedLadderMission(4);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeFalse();
            }
        }
    }
    
}
