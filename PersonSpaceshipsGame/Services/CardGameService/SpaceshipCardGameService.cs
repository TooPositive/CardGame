using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Services.CardGameService
{
    public class SpaceshipCardGameService : ISpaceshipCardGameService
    {
        public ISpaceshipCard? ChooseWinnerCard(ISpaceshipCard card1, ISpaceshipCard card2)
        {
            if (card1.CrewCount == card2.CrewCount)
                return null;

            return card1.CrewCount > card2.CrewCount ? card1 : card2;
        }
    }
}
