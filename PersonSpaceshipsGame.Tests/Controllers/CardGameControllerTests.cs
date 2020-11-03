using NUnit.Framework;
using PersonSpaceshipsGame.Controllers.CardGame;
using PersonSpaceshipsGame.Dtos;
using PersonSpaceshipsGame.Factories;
using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using PersonSpaceshipsGame.Tests.TestCaseSources.Controllers.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Tests.Controllers
{
    public class CardGameControllerTests
    {
        private ICardGameController cardGameController;

        [SetUp]
        public void Setup()
        {
            this.cardGameController = CardGameFactory.Create<ICardGameController>();
        }

        [TestCaseSource(typeof(CardsPlayedTestCases), nameof(CardsPlayedTestCases.Serialiazed))]
        public void ChooseWinnerPersonCard(PlayedCards cards, string desiredResponse)
        {
            var response = cardGameController.CardsPlayed(cards);
            Assert.AreEqual(response, desiredResponse);
        }
    }
}
