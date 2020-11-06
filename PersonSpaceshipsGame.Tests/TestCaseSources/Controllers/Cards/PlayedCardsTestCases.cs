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
using PersonSpaceshipsGame.Models;
using PersonSpaceshipsGame.Controllers.CardGame.Responses;

namespace PersonSpaceshipsGame.Tests.TestCaseSources.Controllers.Cards
{
    public class PlayedCardsTestCases
    {
        public static IEnumerable<TestCaseData> PersonsPlayedCard
        {
            get
            {
                Player player1 = new Player();
                Player player2 = new Player();
                IPersonCard mass10PersonCard = new PersonCard(new Guid(), 10, "Mass 10", player1);                
                IPersonCard mass15PersonCard = new PersonCard(new Guid(), 15, "Mass 15", player2);

                PersonsPlayedCards person1WonCards = new PersonsPlayedCards() { personCard1 = mass15PersonCard, personCard2 = mass10PersonCard };
                PersonsPlayedCards drawCards = new PersonsPlayedCards() { personCard1 = mass15PersonCard, personCard2 = mass15PersonCard };
                PersonsPlayedCards justOneCard = new PersonsPlayedCards() { personCard1 = mass15PersonCard };

                yield return new TestCaseData(person1WonCards, new CardsPlayedResponse() { Winner = mass15PersonCard.Player, Player1 = person1WonCards.personCard1.Player, Player2 = person1WonCards.personCard2.Player});
                yield return new TestCaseData(drawCards, new CardsPlayedResponse() { Player1 = drawCards.personCard1.Player, Player2 = drawCards.personCard2.Player, Exceptions = Models.Cards.Enums.CardPlayedExceptions.Draw});
            }
        }

        public static IEnumerable<TestCaseData> SpaceshipsPlayedCards
        {
            get
            {
                Player player1 = new Player();
                Player player2 = new Player();
                ISpaceshipCard crew10PersonCard = new SpaceshipCard(new Guid(), 10, "Crew 10", player1);                
                ISpaceshipCard crew15PersonCard = new SpaceshipCard(new Guid(), 15, "Crew 15", player2);

                SpaceShipPlayedCards spaceship1Won = new SpaceShipPlayedCards() { card1 = crew15PersonCard, card2 = crew10PersonCard };
                SpaceShipPlayedCards drawCards = new SpaceShipPlayedCards() { card1 = crew15PersonCard, card2 = crew15PersonCard };
                SpaceShipPlayedCards justOneCard = new SpaceShipPlayedCards() { card1 = crew15PersonCard };

                yield return new TestCaseData(spaceship1Won, new CardsPlayedResponse() { Winner = crew15PersonCard.Player, Player1 = spaceship1Won.card1.Player, Player2 = spaceship1Won.card2.Player });
                yield return new TestCaseData(drawCards, new CardsPlayedResponse() { Player1 = drawCards.card1.Player, Player2 = drawCards.card2.Player, Exceptions = Models.Cards.Enums.CardPlayedExceptions.Draw });
            }
        }
    }
}
