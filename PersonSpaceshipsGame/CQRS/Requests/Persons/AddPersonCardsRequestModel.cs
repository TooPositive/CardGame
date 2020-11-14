using MediatR;
using PersonSpaceshipsGame.CQRS.Responses.Persons;
using PersonSpaceshipsGame.Models.Cards.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Requests.Persons
{
    public class AddPersonCardsRequestModel : IRequest<AddPersonCardsResponseModel>
    {
        public IEnumerable<IPersonCard> PersonCards { get; set; }
    }
}
