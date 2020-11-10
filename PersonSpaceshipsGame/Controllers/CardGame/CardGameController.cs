using MediatR;
using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.CQRS.Handlers.QueriesHandlers.Persons;
using PersonSpaceshipsGame.CQRS.Requests;
using PersonSpaceshipsGame.CQRS.Requests.Persons;
using PersonSpaceshipsGame.Dtos;
using PersonSpaceshipsGame.Factories;
using PersonSpaceshipsGame.Models;
using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using PersonSpaceshipsGame.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Controllers.CardGame
{
    public class CardGameController : IDefaultCardGameController, IPersonsPlayedCardGameController, ISpaceShipsPlayedCardGameController
    {
        public IPersonCardGameService personCardGameService { get; set; }
        public ISpaceshipCardGameService spaceshipCardGameService { get; set; }
        public int MaxPlayersCount { get; set; } = Models.Players.PlayerStatics.MaxPlayersCount;

        public CardGameController()
        {
            personCardGameService = GameServiceFactory.Create<IPersonCardGameService>();
            spaceshipCardGameService = GameServiceFactory.Create<ISpaceshipCardGameService>();
        }


        public Enums.CardType ParseCardType(string cardTypeName)
        {
            Enum.TryParse(cardTypeName, out Enums.CardType cardType); //TODO: handle exception
            return cardType;
        }

        //public Player? ChooseWinnerFromRoundCardsPlayed(PlayableCardDto[] cards)
        //{
        //    //TODO: better error handling
        //    if (cards.Select(x => x.CardType).Distinct().Count() != 1)
        //        return null;

        //    var cardType = ParseCardType(cards.Select(x => x.CardType).First());

        //    switch (cardType)
        //    {
        //        case Enums.CardType.Person:
                    
        //            break;
        //        case Enums.CardType.Spaceship:
        //            break;
        //        default:
        //            return null;//TODO: Better error handling
        //    }
        //}

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

        private static void AddPointsToWinner(ICardsPlayedResponse cardsPlayedResponse)
        {
            if (cardsPlayedResponse.Result == Enums.CardResponseResult.Win)
                cardsPlayedResponse.Winner.Points++;
        }
    }
}
