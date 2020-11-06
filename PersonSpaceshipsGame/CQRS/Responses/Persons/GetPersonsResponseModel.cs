using MediatR;
using PersonSpaceshipsGame.Models.Cards.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Responses.Persons
{
    public class GetPersonsResponseModel
    {
        public IEnumerable<IPersonCard> PersonCards { get; set; }
    }
}
