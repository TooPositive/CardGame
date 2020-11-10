using PersonSpaceshipsGame.Dtos;
using PersonSpaceshipsGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Controllers.CardGame
{
    public interface IDefaultCardGameController
    {
        int MaxPlayersCount { get; set; }

        //Player ChooseWinnerFromRoundCardsPlayed(PlayableCardDto[] cards);
    }
}
