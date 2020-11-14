using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using System.Collections.Generic;

namespace PersonSpaceshipsGame.Controllers.CardGame
{
    public interface IPersonsPlayedCardGameController
    {
        IPersonCardGameService personCardGameService { get; set; }
        ICardsPlayedResponse PersonsCardsPlayed(IEnumerable<IPersonCard> playedCards);
    }
}
