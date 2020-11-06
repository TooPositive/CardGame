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
            var compareToResponse = card1.CompareTo(card2);

            if (compareToResponse == 0)
                return null;

            return compareToResponse == 1 ? card1 : card2;
        }
    }
}
