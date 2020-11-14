using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using System.Collections.Generic;

namespace PersonSpaceshipsGame.Controllers.CardGame
{
    public interface ISpaceShipsPlayedCardGameController
    {

        ISpaceshipCardGameService spaceshipCardGameService { get; set; }
        ICardsPlayedResponse SpaceShipCardsPlayed(IEnumerable<ISpaceshipCard> playedCards);
    }
}
