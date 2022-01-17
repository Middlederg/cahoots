using System.Collections.Generic;
using Cahoots.Core;
using FluentAssertions;
using Xunit;

namespace Cahoots.UnitTests
{

    public class SameSumMissionShould
    {
        [Fact]
        public void Be_completed()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Green3, CardMother.Orange2),
                CardSetMother.Create(CardMother.Red1, CardMother.Red3, CardMother.Orange2, CardMother.Orange2),
                CardSetMother.Create(CardMother.Red7, CardMother.Red1, CardMother.Orange3, CardMother.Orange5),
                CardSetMother.Create(CardMother.Blue3, CardMother.Red3, CardMother.Green5, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue5, CardMother.Green3, CardMother.Red1, CardMother.Orange1)
            };


            var mission = new SameSumMission(Color.Orange, Color.Red);

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
                CardSetMother.Create(CardMother.Blue1, CardMother.Red1, CardMother.Orange1, CardMother.Red2),
                CardSetMother.Create(CardMother.Blue1, CardMother.Green4, CardMother.Orange3, CardMother.Red1),
                CardSetMother.Create(CardMother.Blue2, CardMother.Red5, CardMother.Red5, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue3, CardMother.Red4, CardMother.Orange1, CardMother.Orange1),
                CardSetMother.Create(CardMother.Blue6, CardMother.Blue2, CardMother.Blue3, CardMother.Blue5),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red2, CardMother.Red2, CardMother.Orange6),
                CardSetMother.Create(CardMother.Blue1, CardMother.Blue3, CardMother.Red3, CardMother.Orange7),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red2, CardMother.Blue7, CardMother.Blue3),
                CardSetMother.Create(CardMother.Blue6, CardMother.Blue2, CardMother.Blue5, CardMother.Orange1),
                CardSetMother.Create(CardMother.Orange5, CardMother.Orange5, CardMother.Orange4, CardMother.Orange2),
                CardSetMother.Create(CardMother.Red3, CardMother.Red4, CardMother.Red5, CardMother.Red5)
            };

            var mission = new SameSumMission(Color.Orange, Color.Red);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeFalse();
            }
        }
    }
}
