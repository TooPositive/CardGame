﻿using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Dtos
{
    public class PlayedCards
    {
        public Enums.CardType CardType { get; set; }
        public Guid Card1Id { get; set; }
        public Guid Card2Id { get; set; }
    }
}
