using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using PersonSpaceshipsGame.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Services
{
    public class PersonCardGameService : IPersonCardGameService
    {
        public IPersonCard? ChooseWinnerCard(IPersonCard card1, IPersonCard card2)
        {
            var compareToResponse = card1.CompareTo(card2);

            if (compareToResponse == 0)
                return null;

            return compareToResponse == 1 ? card1 : card2;
        }
    }
}
