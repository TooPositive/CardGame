using MediatR;
using PersonSpaceshipsGame.CQRS.Requests;
using PersonSpaceshipsGame.CQRS.Responses;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Handlers.CommandHandlers.Persons
{
    //public class AddPersonCommandHandler : IRequestHandler<SimplePersonRequestModel, SimplePersonResponseModel>
    //{
    //    private readonly CardGameContext _context;
    //    public AddPersonCommandHandler(CardGameContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<SimplePersonResponseModel> Handle(SimplePersonRequestModel request, CancellationToken cancellationToken)
    //    {
    //        IEnumerable<PersonCard> personCardInstances = request.personCards.Select(x => (PersonCard)x);
    //        await _context.AddRangeAsync(personCardInstances);
    //        await _context.SaveChangesAsync();
    //        return new SimplePersonResponseModel{ IsSuccess = true, PersonCards = personCardInstances };
    //    }
    //}
}
