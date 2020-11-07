using NUnit.Framework;
using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.Factories;
using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using PersonSpaceshipsGame.Tests.TestCaseSources.Services.Cards;
using System.Collections.Generic;

namespace PersonSpaceshipsGame.Tests.Services
{
    public class CardGameServiceTests
    {

        private IPersonCardGameService personCardGameService;
        private ISpaceshipCardGameService spaceshipCardGameService;       

        [SetUp]
        public void Setup()
        {
            this.personCardGameService = GameServiceFactory.Create<IPersonCardGameService>();
            this.spaceshipCardGameService = GameServiceFactory.Create<ISpaceshipCardGameService>();
        }

        [TestCaseSource(typeof(ChooseWinnerTestCases), nameof(ChooseWinnerTestCases.PersonTestCases))]
        public void ChooseWinnerPersonCard(List<IPersonCard> cards,  ICardsPlayedResponse desiredResponse)
        {

            ICardsPlayedResponse cardsPlayedResponse = personCardGameService.ChooseWinnerCard(cards);
            Assert.AreEqual(cardsPlayedResponse, desiredResponse);
        }

        [TestCaseSource(typeof(ChooseWinnerTestCases), nameof(ChooseWinnerTestCases.SpaceshipsTestCases))]
        public void ChooseWinnerSpaceshipCard(List<ISpaceshipCard> cards, ICardsPlayedResponse desiredResponse)
        {
            ICardsPlayedResponse winnerCardfromService = spaceshipCardGameService.ChooseWinnerCard(cards);
            Assert.AreEqual(winnerCardfromService, desiredResponse);
        }
    }
}
