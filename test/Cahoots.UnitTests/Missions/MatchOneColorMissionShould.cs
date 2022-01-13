using System.Collections.Generic;
using Cahoots.Core;
using FluentAssertions;
using Xunit;

namespace Cahoots.UnitTests
{
    public class MatchOneColorMissionShould
    {
        [Fact]
        public void Be_completed_when_all_cards_are_blue()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue3, CardMother.Blue1, CardMother.Blue1, CardMother.Blue1),
                CardSetMother.Create(CardMother.Blue1, CardMother.Blue3, CardMother.Blue4, CardMother.Blue7),
                CardSetMother.Create(CardMother.Blue7, CardMother.Blue3, CardMother.Blue7, CardMother.Blue3)
            };

            var mission = new MatchColorMission(4, Color.Blue);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeTrue();
            }
        }

        [Fact]
        public void Be_completed_when_all_cards_are_red()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Red3, CardMother.Red1, CardMother.Red1, CardMother.Red1),
                CardSetMother.Create(CardMother.Red1, CardMother.Red3, CardMother.Red4, CardMother.Red7),
                CardSetMother.Create(CardMother.Red7, CardMother.Red3, CardMother.Red7, CardMother.Red3)
            };

            var mission = new MatchColorMission(4, Color.Red);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeTrue();
            }
        }

        [Fact]
        public void Be_completed_when_all_cards_are_green()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Green3, CardMother.Green1, CardMother.Green1, CardMother.Green1),
                CardSetMother.Create(CardMother.Green1, CardMother.Green3, CardMother.Green4, CardMother.Green7),
                CardSetMother.Create(CardMother.Green7, CardMother.Green3, CardMother.Green7, CardMother.Green3)
            };

            var mission = new MatchColorMission(4, Color.Green);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeTrue();
            }
        }

        [Fact]
        public void Be_completed_when_all_cards_are_orange()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Orange3, CardMother.Orange1, CardMother.Orange1, CardMother.Orange1),
                CardSetMother.Create(CardMother.Orange1, CardMother.Orange3, CardMother.Orange4, CardMother.Orange7),
                CardSetMother.Create(CardMother.Orange7, CardMother.Orange3, CardMother.Orange7, CardMother.Orange3)
            };

            var mission = new MatchColorMission(4, Color.Orange);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeTrue();
            }
        }

        [Fact]
        public void Not_Be_completed_when_not_all_cards_are_blue()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Blue3, CardMother.Blue1, CardMother.Blue1, CardMother.Orange1),
                CardSetMother.Create(CardMother.Blue1, CardMother.Blue3, CardMother.Red3, CardMother.Blue7),
                CardSetMother.Create(CardMother.Blue7, CardMother.Orange1, CardMother.Green3, CardMother.Blue3),
                CardSetMother.Create(CardMother.Red4, CardMother.Red2, CardMother.Orange1, CardMother.Orange1)
            };

            var mission = new MatchColorMission(4, Color.Blue);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeFalse();
            }
        }

        [Fact]
        public void Not_be_completed_when_not_all_cards_are_red()
        {
            var setCollection = new List<CardSet>()
            {
                CardSetMother.Create(CardMother.Red3, CardMother.Red1, CardMother.Red1, CardMother.Orange1),
                CardSetMother.Create(CardMother.Red1, CardMother.Red3, CardMother.Blue3, CardMother.Red7),
                CardSetMother.Create(CardMother.Blue7, CardMother.Orange1, CardMother.Green3, CardMother.Red3),
                CardSetMother.Create(CardMother.Red4, CardMother.Red2, CardMother.Orange1, CardMother.Orange1)
            };

            var mission = new MatchColorMission(4, Color.Red);

            foreach (var cardSet in setCollection)
            {
                mission.CanBeCompleted(cardSet).Should().BeFalse();
            }
        }
    }
}
