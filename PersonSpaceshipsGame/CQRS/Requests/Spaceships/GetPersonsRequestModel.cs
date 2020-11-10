using MediatR;
using PersonSpaceshipsGame.CQRS.Responses.Persons;
using PersonSpaceshipsGame.CQRS.Responses.Spaceships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Requests.Persons
{
    public class GetSpaceshipRequestModel : IRequest<GetSpaceshipResponseModel>
    {
        public IEnumerable<Guid> SpaceshipIds { get; set; }
    }
}
