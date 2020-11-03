using NUnit.Framework;
using PersonSpaceshipsGame.Dtos;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PersonSpaceshipsGame.Tests.TestCaseSources.Controllers.Cards
{
    public class CardsPlayedTestCases
    {
        public static IEnumerable<TestCaseData> Serialiazed
        {
            get
            {
                IPersonCard mass10PersonCard = new PersonCard(1, 10, "Mass 10");
                IPersonCard mass15PersonCard = new PersonCard(2, 15, "Mass 15");
                ISpaceshipCard crewCount10PersonCard = new SpaceshipCard(1, 10, "CrewCount 10");
                ISpaceshipCard crewCount15PersonCard = new SpaceshipCard(2, 15, "CrewCount 15");

                PlayedCards personPlayedCards = new PlayedCards() { CardType = Models.Cards.Enums.CardType.Person, JsonCard1 = JsonSerializer.Serialize(mass10PersonCard), JsonCard2 = JsonSerializer.Serialize(mass15PersonCard) };
                PlayedCards drawPersonPlayedCards = new PlayedCards() { CardType = Models.Cards.Enums.CardType.Person, JsonCard1 = JsonSerializer.Serialize(mass10PersonCard), JsonCard2 = JsonSerializer.Serialize(mass10PersonCard) };
                PlayedCards spaceshipPlayedCards = new PlayedCards() { CardType = Models.Cards.Enums.CardType.Spaceship, JsonCard1 = JsonSerializer.Serialize(crewCount10PersonCard), JsonCard2 = JsonSerializer.Serialize(crewCount15PersonCard) };
                PlayedCards drwaSpaceshipPlayedCards = new PlayedCards() { CardType = Models.Cards.Enums.CardType.Spaceship, JsonCard1 = JsonSerializer.Serialize(crewCount10PersonCard), JsonCard2 = JsonSerializer.Serialize(crewCount10PersonCard) };
                PlayedCards justOneCard = new PlayedCards() { CardType = Models.Cards.Enums.CardType.Spaceship, JsonCard1 = JsonSerializer.Serialize(crewCount10PersonCard) };

                yield return new TestCaseData(personPlayedCards, "OK");
                yield return new TestCaseData(spaceshipPlayedCards, "OK");
                yield return new TestCaseData(justOneCard, "Not enough cards");
                yield return new TestCaseData(drawPersonPlayedCards, null);
                yield return new TestCaseData(drwaSpaceshipPlayedCards, null);
            }
        }
    }
}
