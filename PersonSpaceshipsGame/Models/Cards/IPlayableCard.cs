using PersonSpaceshipsGame.Models.Players;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PersonSpaceshipsGame.Models.Cards.Enums;

namespace PersonSpaceshipsGame.Models.Cards
{
    public interface IPlayableCard
    {        
        Guid Id { get; set; }
        string Name { get; set; }

        [NotMapped]
        public Player Player { get; set; }

        [Column("CardType")]
        public string CardTypeString
        {
            get { return CardType.ToString(); }
            private set { CardType = Enums.ParseEnum<CardType>(value); }
        }

        [NotMapped]
        public Enums.CardType CardType { get; set; }

    }
}
