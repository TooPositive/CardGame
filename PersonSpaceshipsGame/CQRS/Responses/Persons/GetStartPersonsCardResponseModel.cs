using MediatR;
using PersonSpaceshipsGame.CQRS.Requests.Persons;
using PersonSpaceshipsGame.Models.Cards.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Responses.Persons
{
    public class GetStartPersonsCardResponseModel : IRequest<GetStartPersonsCardRequestModel>
    {
        public IEnumerable<PersonCard> Cards { get; set; }
    }
}
