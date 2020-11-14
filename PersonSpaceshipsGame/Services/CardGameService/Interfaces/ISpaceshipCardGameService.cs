using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Services.CardGameService.Interfaces
{
    public interface ISpaceshipCardGameService
    {
        ICardsPlayedResponse ChooseWinnerCard(IEnumerable<ISpaceshipCard> cards);
    }
}
