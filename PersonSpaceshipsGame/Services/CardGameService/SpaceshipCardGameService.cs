using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Models.Players;
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
        //TODO: Think about merging this method to one with custom comparer as parameter
        public ICardsPlayedResponse ChooseWinnerCard(IEnumerable<ISpaceshipCard> cards)
        {
            List<ISpaceshipCard> sortedCardsList = cards.ToList().OrderByDescending(x => x.CrewCount).ToList();

            if (sortedCardsList.Count <= 1)
                return new CardsPlayedResponse() { Players = sortedCardsList.Select(x => x.Player), Result = Enums.CardResponseResult.NotEnoughCards };

            if (sortedCardsList.Count > PlayerStatics.MaxPlayersCount)
                return new CardsPlayedResponse() { Players = sortedCardsList.Select(x => x.Player), Result = Enums.CardResponseResult.TooMuchCards };

            // if there is just one card with same amount of CrewCount as first one call a draw on a round
            if (sortedCardsList.First().CrewCount.Equals(sortedCardsList[1].CrewCount))
                return new CardsPlayedResponse() { Players = sortedCardsList.Select(x => x.Player), Result = Enums.CardResponseResult.Draw };

            return new CardsPlayedResponse() { Winner = sortedCardsList.First().Player, Players = sortedCardsList.Select(x => x.Player), Result = Enums.CardResponseResult.Win };

        }
    }
}
