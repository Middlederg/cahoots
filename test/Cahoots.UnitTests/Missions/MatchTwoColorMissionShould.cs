using System.Collections.Generic;
using Cahoots.Core;
using FluentAssertions;
using Xunit;

namespace Cahoots.UnitTests
{
    public class MatchTwoColorMissionShould
    {
        [Fact]
        public void Be_completed_when_all_cards_are_blue_or_red()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue3, CardMother.Red3, CardMother.Blue3, CardMother.Red3),
                CardSetMother.Create(CardMother.Blue1, CardMother.Red1, CardMother.Blue1, CardMother.Red1),
                CardSetMother.Create(CardMother.Blue7, CardMother.Red7, CardMother.Blue7, CardMother.Red7)
            };

            var mission = new MatchColorMission(4, Color.Blue, Color.Red);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeTrue();
            }
        }

        [Fact]
        public void Be_completed_when_all_cards_are_blue_or_green()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue3, CardMother.Green3, CardMother.Blue3, CardMother.Green3),
                CardSetMother.Create(CardMother.Blue1, CardMother.Green1, CardMother.Blue1, CardMother.Green1),
                CardSetMother.Create(CardMother.Blue7, CardMother.Green7, CardMother.Blue7, CardMother.Green7)
            };

            var mission = new MatchColorMission(4, Color.Blue, Color.Green);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeTrue();
            }
        }

        [Fact]
        public void Be_completed_when_all_cards_are_blue_or_orange()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue3, CardMother.Orange3, CardMother.Blue3, CardMother.Orange3),
                CardSetMother.Create(CardMother.Blue1, CardMother.Orange1, CardMother.Blue1, CardMother.Orange1),
                CardSetMother.Create(CardMother.Blue7, CardMother.Orange7, CardMother.Blue7, CardMother.Orange7)
            };

            var mission = new MatchColorMission(4, Color.Blue, Color.Orange);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeTrue();
            }

        }

        [Fact]
        public void Be_completed_when_two_cards_are_blue_or_red()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue3, CardMother.Orange3, CardMother.Green3, CardMother.Red3),
                CardSetMother.Create(CardMother.Blue1, CardMother.Orange1, CardMother.Green1, CardMother.Red1),
                CardSetMother.Create(CardMother.Blue7, CardMother.Orange7, CardMother.Green7, CardMother.Red7)
            };

            var mission = new MatchColorMission(2, Color.Blue, Color.Red);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeTrue();
            }
        }

        [Fact]
        public void Not_completed_when_less_than_three_cards_are_blue_or_red()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue3, CardMother.Orange3, CardMother.Green3, CardMother.Orange1),
                CardSetMother.Create(CardMother.Red4, CardMother.Orange3, CardMother.Green3, CardMother.Orange1),
                CardSetMother.Create(CardMother.Blue1, CardMother.Orange1, CardMother.Green1, CardMother.Blue1),
                CardSetMother.Create(CardMother.Blue7, CardMother.Orange7, CardMother.Green7, CardMother.Red3)
            };

            var mission = new MatchColorMission(3, Color.Blue, Color.Red);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeFalse();
            }
        }
    }
}
