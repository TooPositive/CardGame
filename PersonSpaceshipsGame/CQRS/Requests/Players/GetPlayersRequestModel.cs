using MediatR;
using PersonSpaceshipsGame.CQRS.Requests.Cards;
using PersonSpaceshipsGame.CQRS.Responses.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Requests.Players
{
    public class GetPlayersRequestModel : IRequest<GetPlayersResponseModel>
    {
        public IEnumerable<Guid> Guids { get; set; }
    }
}
