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
using PersonSpaceshipsGame.Models.Players;

namespace PersonSpaceshipsGame.Tests.TestCaseSources.Controllers.Cards
{
    public class PlayedCardsTestCases
    {
        public static IEnumerable<TestCaseData> PersonsPlayedCard
        {
            get
            {
                List<Player> players = GetPlayers(2);
                IPersonCard mass10PersonCard = new PersonCard(new Guid(), 10, "Mass 10", players[0]);
                IPersonCard mass15PersonCard = new PersonCard(new Guid(), 15, "Mass 15", players[1]);

                List<IPersonCard> person1WonCards = new List<IPersonCard>() { mass15PersonCard, mass10PersonCard };
                List<IPersonCard> drawCards = new List<IPersonCard>() { mass15PersonCard, mass15PersonCard };
                List<IPersonCard> justOneCard = new List<IPersonCard>() { mass15PersonCard };


                yield return new TestCaseData(person1WonCards, new CardsPlayedResponse() { Winner = mass15PersonCard.Player, Players = players, Result = Models.Cards.Enums.CardResponseResult.Win });
                yield return new TestCaseData(drawCards, new CardsPlayedResponse() { Players = players, Result = Models.Cards.Enums.CardResponseResult.Draw });
                yield return new TestCaseData(justOneCard, new CardsPlayedResponse() { Players = players, Result = Models.Cards.Enums.CardResponseResult.NotEnoughCards });
            }
        }

        public static IEnumerable<TestCaseData> SpaceshipsPlayedCards
        {
            get
            {
                List<Player> players = GetPlayers(2);
                ISpaceshipCard crew10PersonCard = new SpaceshipCard(new Guid(), 10, "Crew 10", players[0]);
                ISpaceshipCard crew15PersonCard = new SpaceshipCard(new Guid(), 15, "Crew 15", players[1]);

                List<ISpaceshipCard> spaceship1Won = new List<ISpaceshipCard>() { crew15PersonCard, crew10PersonCard };
                List<ISpaceshipCard> drawCards = new List<ISpaceshipCard>() { crew15PersonCard, crew15PersonCard };
                List<ISpaceshipCard> justOneCard = new List<ISpaceshipCard>() { crew15PersonCard };

                yield return new TestCaseData(spaceship1Won, new CardsPlayedResponse() { Winner = crew15PersonCard.Player, Players = players, Result = Models.Cards.Enums.CardResponseResult.Win });
                yield return new TestCaseData(drawCards, new CardsPlayedResponse() { Players = players, Result = Models.Cards.Enums.CardResponseResult.Draw });
                yield return new TestCaseData(justOneCard, new CardsPlayedResponse() { Players = players, Result = Models.Cards.Enums.CardResponseResult.NotEnoughCards });
            }
        }

        static List<Player> GetPlayers(int count)
        {
            List<Player> players = new List<Player>();
            for (int i = 0; i < count; i++)
                players.Add(new Player());
            return players;
        }
    }
}
