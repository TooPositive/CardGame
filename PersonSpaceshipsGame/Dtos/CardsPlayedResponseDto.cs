using PersonSpaceshipsGame.Models;
using PersonSpaceshipsGame.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Dtos
{
    public class CardsPlayedResponseDto
    {
        public Player? Winner { get; set; }
        public Enums.CardResponseResult Result { get; set; }
    }
}
