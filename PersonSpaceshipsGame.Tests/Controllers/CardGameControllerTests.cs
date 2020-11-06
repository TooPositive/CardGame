using NUnit.Framework;
using PersonSpaceshipsGame.Controllers.CardGame;
using PersonSpaceshipsGame.Controllers.CardGame.Responses;
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
        private CardGameController _cardGameController;

        [SetUp]
        public void Setup()
        {
            _cardGameController = new CardGameController();
        }

        [TestCaseSource(typeof(PlayedCardsTestCases), nameof(PlayedCardsTestCases.PersonsPlayedCard))]
        public void PersonsCardsPlayed(PersonsPlayedCards cards, CardsPlayedResponse desiredResponse)
        {
            //TODO: Validate points
            var response = _cardGameController.PersonsCardsPlayed(cards.personCard1, cards.personCard2);
            Assert.IsTrue(response.Equals(desiredResponse));
        }

        [TestCaseSource(typeof(PlayedCardsTestCases), nameof(PlayedCardsTestCases.SpaceshipsPlayedCards))]
        public void CardsPlayed(SpaceShipPlayedCards cards, CardsPlayedResponse desiredResponse)
        {
            //TODO: Validate points
            var response = _cardGameController.SpaceShipCardsPlayed(cards.card1, cards.card2);
            Assert.IsTrue(response.Equals(desiredResponse));
        }
    }
}
