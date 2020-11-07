using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Services.CardGameService.Interfaces
{
    public interface IPersonCardGameService : ICardGameService
    {
        ICardsPlayedResponse ChooseWinnerCard(IEnumerable<IPersonCard> cards);
    }
}
