using MediatR;
using PersonSpaceshipsGame.CQRS.Responses.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Requests.Persons
{
    public class GetPersonsRequestModel : IRequest<GetPersonsResponseModel>
    {
        public IEnumerable<Guid> PersonIds { get; set; }
    }
}
