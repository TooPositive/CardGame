using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.Models.Cards.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Services.CardGameService.Interfaces
{
    public interface IPersonCardGameService
    {
        ICardsPlayedResponse ChooseWinnerCard(IEnumerable<IPersonCard> cards);
    }
}
