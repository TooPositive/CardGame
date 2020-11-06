using PersonSpaceshipsGame.Models.Players;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Models.Cards.Spaceships
{
    public class SpaceshipCard : ISpaceshipCard
    {
        public SpaceshipCard(Guid id, int crewCount, string name, Player player)
        {
            Id = id;
            CrewCount = crewCount;
            Name = name;
            Player = player;
        }

        public Enums.CardType CardType { get; set; } = Enums.CardType.Spaceship;

        public Guid Id { get; set; }
        public int CrewCount { get; set; }
        public string Name { get; set; }        
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
