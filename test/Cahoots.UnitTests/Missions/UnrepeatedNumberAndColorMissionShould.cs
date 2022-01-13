using System.Collections.Generic;
using Cahoots.Core;
using FluentAssertions;
using Xunit;

namespace Cahoots.UnitTests
{
    public class UnrepeatedNumberAndColorMissionShould
    {
        [Fact]
        public void Be_completed()
        {
            var setCollection = new List<CardSet>() {
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Orange4),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Orange5),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red5, CardMother.Green4, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue3, CardMother.Red4, CardMother.Green7, CardMother.Orange6),
                CardSetMother.Create(CardMother.Blue6, CardMother.Red1, CardMother.Green7, CardMother.Orange2),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red1, CardMother.Green6, CardMother.Orange5),
            };

            var mission = new UnrepeatedMission(numbers: true, colors: true);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeTrue();
            }
        }

        [Fact]
        public void Not_completed()
        {
            var setCollection = new List<CardSet>() {
                CardSetMother.Create(CardMother.Blue1, CardMother.Red1, CardMother.Green1, CardMother.Red1),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Green3),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red5, CardMother.Red5, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue3, CardMother.Red4, CardMother.Orange1, CardMother.Orange1),
                CardSetMother.Create(CardMother.Blue6, CardMother.Blue2, CardMother.Blue3, CardMother.Blue6),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red7, CardMother.Red2, CardMother.Orange6),
                CardSetMother.Create(CardMother.Blue1, CardMother.Blue1, CardMother.Blue1, CardMother.Blue1),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Orange1),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red5, CardMother.Green4, CardMother.Orange5),
                CardSetMother.Create(CardMother.Blue3, CardMother.Red4, CardMother.Green7, CardMother.Orange3)
            };

            var mission = new UnrepeatedMission(numbers: true, colors: true);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeFalse();
            }
        }
    }
}