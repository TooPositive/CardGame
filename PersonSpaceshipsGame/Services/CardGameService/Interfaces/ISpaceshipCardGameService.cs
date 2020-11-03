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
        ISpaceshipCard? ChooseWinnerCard(ISpaceshipCard card1, ISpaceshipCard card2);
    }
}
