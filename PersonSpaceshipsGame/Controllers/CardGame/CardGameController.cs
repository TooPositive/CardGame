using PersonSpaceshipsGame.Dtos;
using PersonSpaceshipsGame.Factories;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using PersonSpaceshipsGame.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Controllers.CardGame
{
    public class CardGameController : ICardGameController
    {
        public IPersonCardGameService personCardGameService { get; set; }
        public ISpaceshipCardGameService spaceshipCardGameService { get; set; }
        public int MaxPlayersCount { get; set; } = 2;

        public CardGameController()
        {
            personCardGameService = GameServiceFactory.Create<IPersonCardGameService>();
            spaceshipCardGameService = GameServiceFactory.Create<ISpaceshipCardGameService>();
        }

        public string CardsPlayed(PlayedCards playedCards)
        {
            if (string.IsNullOrEmpty(playedCards.JsonCard1) || string.IsNullOrEmpty(playedCards.JsonCard2))
                return "Not enough cards";


            // how to get this proper cards.... : ( 

            //try
            //{
            //    switch (playedCards.CardType)
            //    {
            //        case Models.Cards.Enums.CardType.Person:
            //            break;
            //        case Models.Cards.Enums.CardType.Spaceship:
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            return "";
        }
    }
}
