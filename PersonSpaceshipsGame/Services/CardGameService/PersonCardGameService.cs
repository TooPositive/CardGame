using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Models.Players;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using PersonSpaceshipsGame.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Services
{
    public class PersonCardGameService : IPersonCardGameService
    {
        //TODO: Think about merging this method to one with custom comparer as parameter
        public ICardsPlayedResponse ChooseWinnerCard(IEnumerable<IPersonCard> cards)
        {
            List<IPersonCard> sortedCardsList = cards.OrderByDescending(x => x.Mass).ToList();

            if (sortedCardsList.Count <= 1)
                return new CardsPlayedResponse() { Players = sortedCardsList.Select(x => x.Player), Result = Enums.CardResponseResult.NotEnoughCards };

            if (sortedCardsList.Count > PlayerStatics.MaxPlayersCount)
                return new CardsPlayedResponse() { Players = sortedCardsList.Select(x => x.Player), Result = Enums.CardResponseResult.TooMuchCards };

            // if there is just one card with same amount of mass as first one call a draw on a round
            if (sortedCardsList.First().Mass.Equals(sortedCardsList[1].Mass))
                return new CardsPlayedResponse() { Players = sortedCardsList.Select(x => x.Player), Result = Enums.CardResponseResult.Draw };

            return new CardsPlayedResponse() { Winner = sortedCardsList.First().Player, Players = sortedCardsList.Select(x => x.Player), Result = Enums.CardResponseResult.Win };

        }
    }
}
