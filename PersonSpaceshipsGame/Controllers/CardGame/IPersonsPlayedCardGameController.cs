using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.Dtos;
using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using PersonSpaceshipsGame.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Controllers.CardGame
{
    public interface IPersonsPlayedCardGameController
    {
        IPersonCardGameService personCardGameService { get; set; }

        CardsPlayedResponse PersonsCardsPlayed(IPersonCard card1, IPersonCard card2);
    }
}
