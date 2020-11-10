using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonSpaceshipsGame.CQRS.Requests.Persons;
using PersonSpaceshipsGame.CQRS.Responses.Persons;
using PersonSpaceshipsGame.CQRS.Responses.Spaceships;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Handlers.QueriesHandlers.Persons
{
    public class GetAllSpaceshipsQueryHandler : IRequestHandler<GetSpaceshipRequestModel, GetSpaceshipResponseModel>
    {
        private readonly CardGameContext _context;
        public GetAllSpaceshipsQueryHandler(CardGameContext context)
        {
            _context = context;
        }

        public async Task<GetSpaceshipResponseModel> Handle(GetSpaceshipRequestModel request, CancellationToken cancellationToken)
        {
            IQueryable<SpaceshipCard> query;
            if (request.SpaceshipIds.Any())
                query = _context.SpaceshipCards.Where(x => request.SpaceshipIds.Contains(x.Id));
            else
                query = _context.SpaceshipCards;

            List<SpaceshipCard> cards = await query.ToListAsync();
            return new GetSpaceshipResponseModel { SpaceshipCards = cards};
        }
    }
}
