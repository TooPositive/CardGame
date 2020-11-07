using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Services.CardGameService.Interfaces
{
    public interface ISpaceshipCardGameService : ICardGameService
    {
        ICardsPlayedResponse ChooseWinnerCard(IEnumerable<ISpaceshipCard> cards);
    }
}
