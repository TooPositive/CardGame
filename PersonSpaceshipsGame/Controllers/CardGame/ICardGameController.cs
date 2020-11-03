using PersonSpaceshipsGame.Dtos;
using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using PersonSpaceshipsGame.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Controllers.CardGame
{
    public interface ICardGameController
    {
        int MaxPlayersCount { get; set; }

        IPersonCardGameService personCardGameService { get; set; }
        ISpaceshipCardGameService spaceshipCardGameService { get; set; }

        string CardsPlayed(PlayedCards playedCards); // TODO: make a better return message
    }
}
