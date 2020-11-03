using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Models.Cards.Spaceships
{
    public interface ISpaceshipCard : IPlayableCard
    {
        public int CrewCount { get; set; }
    }
}
