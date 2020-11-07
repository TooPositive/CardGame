using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Controllers.CardGame
{
    public interface ISpaceShipsPlayedCardGameController
    {

        ISpaceshipCardGameService spaceshipCardGameService { get; set; }

        ICardsPlayedResponse SpaceShipCardsPlayed(IEnumerable<ISpaceshipCard> playedCards);
    }
}
