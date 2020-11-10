using PersonSpaceshipsGame.Models.Cards.Spaceships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Responses.Spaceships
{
    public class GetSpaceshipResponseModel
    {
        public IEnumerable<ISpaceshipCard> SpaceshipCards { get; set; }
    }
}
