using PersonSpaceshipsGame.Models;
using PersonSpaceshipsGame.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Controllers.CardGame.Responses
{
    public class CardsPlayedResponse : ICardsPlayedResponse
    {
        public Player? Winner { get; set; }
        public Enums.CardResponseResult Result { get; set; }
        public IEnumerable<Player> Players { get; set; }

        public override bool Equals(object obj)
        {
            ICardsPlayedResponse cardResponseObject = obj as ICardsPlayedResponse;

            if (cardResponseObject == null)
                return false;

            return Winner == cardResponseObject.Winner && Result == cardResponseObject.Result;
        }
    }
}
