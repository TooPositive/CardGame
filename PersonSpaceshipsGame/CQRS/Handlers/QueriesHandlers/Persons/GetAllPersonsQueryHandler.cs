using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonSpaceshipsGame.CQRS.Requests.Persons;
using PersonSpaceshipsGame.CQRS.Responses.Persons;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Handlers.QueriesHandlers.Persons
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetPersonsRequestModel, GetPersonsResponseModel>
    {
        private readonly CardGameContext _context;
        public GetAllPersonsQueryHandler(CardGameContext context)
        {
            _context = context;
        }

        public async Task<GetPersonsResponseModel> Handle(GetPersonsRequestModel request, CancellationToken cancellationToken)
        {
            IQueryable<PersonCard> query;
            if (request.PersonIds.Any())
                query = _context.PersonCards.Where(x => request.PersonIds.Contains(x.Id));
            else
                query = _context.PersonCards;

            List<PersonCard> cards = await query.ToListAsync();
            return new GetPersonsResponseModel { PersonCards = cards};
        }
    }
}
