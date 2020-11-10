using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Responses.Players
{
    public class GetPlayersResponseModel
    {
        public IEnumerable<PersonSpaceshipsGame.Models.Player> Players { get; set; }
    }
}
