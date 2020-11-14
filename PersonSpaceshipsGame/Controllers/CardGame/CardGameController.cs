using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.Factories;
using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using System;
using System.Collections.Generic;

namespace PersonSpaceshipsGame.Controllers.CardGame
{
    public class CardGameController : ICardGameController
    {
        public IPersonCardGameService personCardGameService { get; set; }
        public ISpaceshipCardGameService spaceshipCardGameService { get; set; }
        public int MaxPlayersCount { get; set; } = Models.Players.PlayerStatics.MaxPlayersCount;

        public CardGameController()
        {
            personCardGameService = GameServiceFactory.Create<IPersonCardGameService>();
            spaceshipCardGameService = GameServiceFactory.Create<ISpaceshipCardGameService>();
        }

        public ICardsPlayedResponse PersonsCardsPlayed(IEnumerable<IPersonCard> cards)
        {
            ICardsPlayedResponse cardsPlayedResponse = personCardGameService.ChooseWinnerCard(cards);
            AddPointsToWinner(cardsPlayedResponse);
            return cardsPlayedResponse;
        }

        public ICardsPlayedResponse SpaceShipCardsPlayed(IEnumerable<ISpaceshipCard> cards)
        {
            ICardsPlayedResponse cardsPlayedResponse = spaceshipCardGameService.ChooseWinnerCard(cards);
            AddPointsToWinner(cardsPlayedResponse);
            return cardsPlayedResponse;
        }

        private void AddPointsToWinner(ICardsPlayedResponse cardsPlayedResponse)
        {
            if (cardsPlayedResponse.Result == Enums.CardResponseResult.Win)
                cardsPlayedResponse.Winner.Points++;
        }
    }
}
