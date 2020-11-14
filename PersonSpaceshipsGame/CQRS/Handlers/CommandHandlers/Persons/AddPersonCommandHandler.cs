using MediatR;
using PersonSpaceshipsGame.CQRS.Requests;
using PersonSpaceshipsGame.CQRS.Requests.Persons;
using PersonSpaceshipsGame.CQRS.Responses;
using PersonSpaceshipsGame.CQRS.Responses.Persons;
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
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCardsRequestModel, AddPersonCardsResponseModel>
    {
        private readonly CardGameContext _context;
        public AddPersonCommandHandler(CardGameContext context)
        {
            _context = context;
        }

        public async Task<AddPersonCardsResponseModel> Handle(AddPersonCardsRequestModel request, CancellationToken cancellationToken)
        {
            IEnumerable<PersonCard> personCardInstances = request.PersonCards.Select(x => (PersonCard)x);
            try
            {
                await _context.AddRangeAsync(personCardInstances);
                await _context.SaveChangesAsync();
                return new AddPersonCardsResponseModel { IsSuccess = true };

            }
            catch (Exception)
            {
                return new AddPersonCardsResponseModel { IsSuccess = false };
            }
        }
    }
}
