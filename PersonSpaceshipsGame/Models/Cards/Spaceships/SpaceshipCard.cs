using PersonSpaceshipsGame.Models.Players;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PersonSpaceshipsGame.Models.Cards.Enums;

namespace PersonSpaceshipsGame.Models.Cards.Spaceships
{
    public class SpaceshipCard : ISpaceshipCard
    {
        [Column("CardType")]
        public string CardTypeString
        {
            get { return CardType.ToString(); }
            private set { CardType = Enums.ParseEnum<CardType>(value); }
        }

        [NotMapped]
        public CardType CardType { get; set; } = CardType.Spaceship;
        public Guid Id { get; set; }
        public int CrewCount { get; set; }
        public string Name { get; set; }        

        [NotMapped]
        public Player Player { get; set; }

        public int CompareTo(ISpaceshipCard other)
        {
            if (this.CrewCount < other.CrewCount)
                return -1;
            if (this.CrewCount == other.CrewCount)
                return 0;
            return 1;
        }
    }
}
