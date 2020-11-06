using PersonSpaceshipsGame.Models;
using PersonSpaceshipsGame.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Controllers.CardGame.Responses
{
    public class CardsPlayedResponse
    {
        public Player? Winner { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Enums.CardPlayedExceptions Exceptions { get; set; }

        public override bool Equals(object obj)
        {
            CardsPlayedResponse cardResponsObject = obj as CardsPlayedResponse;

            if (cardResponsObject == null)
                return false;

            return Winner == cardResponsObject.Winner && Player1 == cardResponsObject.Player1 && Player2 == cardResponsObject.Player2 && Exceptions == cardResponsObject.Exceptions;
        }
    }
}
