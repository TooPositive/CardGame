using MediatR;
using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.CQRS.Handlers.QueriesHandlers.Persons;
using PersonSpaceshipsGame.CQRS.Requests;
using PersonSpaceshipsGame.CQRS.Requests.Persons;
using PersonSpaceshipsGame.Dtos;
using PersonSpaceshipsGame.Factories;
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
        public int MaxPlayersCount { get; set; } = 2;

        public CardGameController()
        {
            personCardGameService = GameServiceFactory.Create<IPersonCardGameService>();
            spaceshipCardGameService = GameServiceFactory.Create<ISpaceshipCardGameService>();
        }

        public CardsPlayedResponse PersonsCardsPlayed(IPersonCard card1, IPersonCard card2)
        {
            var winnerCard = personCardGameService.ChooseWinnerCard(card1, card2);
            return CardsPlayed(card1, card2, winnerCard);
        }

        public CardsPlayedResponse SpaceShipCardsPlayed(ISpaceshipCard card1, ISpaceshipCard card2)
        {
            var winnerCard = spaceshipCardGameService.ChooseWinnerCard(card1, card2);
            return CardsPlayed(card1, card2, winnerCard);
        }

        private CardsPlayedResponse CardsPlayed(IPlayableCard card1, IPlayableCard card2, IPlayableCard winnerCard)
        {
            CardsPlayedResponse cardsPlayedResponse = new CardsPlayedResponse() { Player1 = card1.Player, Player2 = card2.Player };

            if (winnerCard == null)
                cardsPlayedResponse.Exceptions = Enums.CardPlayedExceptions.Draw;
            else
            {
                cardsPlayedResponse.Winner = winnerCard.Player;
                winnerCard.Player.Points++;
            }
            return cardsPlayedResponse;
        }
    }
}
