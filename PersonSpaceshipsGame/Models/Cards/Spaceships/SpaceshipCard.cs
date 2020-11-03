using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Models.Cards.Spaceships
{
    public class SpaceshipCard : ISpaceshipCard
    {
        public SpaceshipCard(int id, int crewCount, string name)
        {
            Id = id;
            CrewCount = crewCount;
            Name = name;
        }

        public int Id { get; set; }
        public int CrewCount { get; set; }        
        public string Name { get; set; }

    }
}
