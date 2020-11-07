using NUnit.Framework;
using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.Models;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Tests.TestCaseSources.Services.Cards
{
    public class ChooseWinnerTestCases
    {
        public static IEnumerable<TestCaseData> PersonTestCases
        {
            get
            {
                IPersonCard mass10PersonCard = new PersonCard(new Guid(), 10, "Mass 10", new Player());
                IPersonCard mass15PersonCard = new PersonCard(new Guid(), 15, "Mass 15", new Player());

                List<IPersonCard> mass15CardWin = new List<IPersonCard>() { mass15PersonCard, mass10PersonCard };
                List<IPersonCard> drawCards = new List<IPersonCard>() { mass15PersonCard, mass15PersonCard };
                List<IPersonCard> oneCard = new List<IPersonCard>() { mass15PersonCard };

                yield return new TestCaseData(mass15CardWin, new CardsPlayedResponse() { Players = mass15CardWin.Select(x=> x.Player), Winner = mass15PersonCard.Player, Result = Models.Cards.Enums.CardResponseResult.Win });
                yield return new TestCaseData(drawCards, new CardsPlayedResponse() { Players = drawCards.Select(x => x.Player), Result = Models.Cards.Enums.CardResponseResult.Draw });
                yield return new TestCaseData(oneCard, new CardsPlayedResponse() { Players = oneCard.Select(x => x.Player), Result = Models.Cards.Enums.CardResponseResult.NotEnoughCards });
            }
        }

        public static IEnumerable<TestCaseData> SpaceshipsTestCases
        {
            get
            {
                ISpaceshipCard crewCount10PersonCard = new SpaceshipCard(new Guid(), 10, "CrewCount 10", new Player());
                ISpaceshipCard crewCount15PersonCard = new SpaceshipCard(new Guid(), 15, "CrewCount 15", new Player());

                List<ISpaceshipCard> crew15WinCards = new List<ISpaceshipCard>() { crewCount15PersonCard, crewCount10PersonCard };
                List<ISpaceshipCard> drawCards = new List<ISpaceshipCard>() { crewCount15PersonCard, crewCount15PersonCard };
                List<ISpaceshipCard> oneCard = new List<ISpaceshipCard>() { crewCount15PersonCard };

                yield return new TestCaseData(crew15WinCards, new CardsPlayedResponse() { Players = crew15WinCards.Select(x => x.Player), Winner = crewCount15PersonCard.Player, Result = Models.Cards.Enums.CardResponseResult.Win });
                yield return new TestCaseData(drawCards, new CardsPlayedResponse() { Players = drawCards.Select(x => x.Player), Result = Models.Cards.Enums.CardResponseResult.Draw });
                yield return new TestCaseData(oneCard, new CardsPlayedResponse() { Players = oneCard.Select(x => x.Player), Result = Models.Cards.Enums.CardResponseResult.NotEnoughCards });
            }
        }
    }
}
