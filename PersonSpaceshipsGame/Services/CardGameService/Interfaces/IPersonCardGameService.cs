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
        IPersonCard? ChooseWinnerCard(IPersonCard card1, IPersonCard card2);
    }
}
