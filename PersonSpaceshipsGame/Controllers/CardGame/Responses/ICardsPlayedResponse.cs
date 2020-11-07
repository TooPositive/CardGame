using PersonSpaceshipsGame.Models;
using PersonSpaceshipsGame.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Controllers.CardGame.Responses
{
    public interface ICardsPlayedResponse
    {
        Player? Winner { get; set; }
        IEnumerable<Player> Players { get; set; }
        Enums.CardResponseResult Result { get; set; }
    }
}
