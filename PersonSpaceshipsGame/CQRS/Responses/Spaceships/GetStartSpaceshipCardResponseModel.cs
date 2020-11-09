using PersonSpaceshipsGame.Models.Cards.Spaceships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Responses.Spaceships
{
    public class GetStartSpaceshipCardResponseModel
    {
        public IEnumerable<SpaceshipCard> Cards { get; set; }
    }
}
