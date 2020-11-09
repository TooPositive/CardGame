using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonSpaceshipsGame.CQRS.Requests.Spaceships;
using PersonSpaceshipsGame.CQRS.Responses.Spaceships;
using PersonSpaceshipsGame.Models;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Models.Database;
using PersonSpaceshipsGame.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Handlers.QueriesHandlers.Spaceships
{
    //TODO: this should be one query with Persons query handler
    public class GetStartSpaceshipCardsQueryHandler : IRequestHandler<GetStartSpaceshipCardRequestModel, GetStartSpaceshipCardResponseModel>
    {
        private readonly CardGameContext _context;
        public GetStartSpaceshipCardsQueryHandler(CardGameContext context)
        {
            _context = context;
        }

        public async Task<GetStartSpaceshipCardResponseModel> Handle(GetStartSpaceshipCardRequestModel request, CancellationToken cancellationToken)
        {
            List<SpaceshipCard> cards = new List<SpaceshipCard>();
            var allSpaceShipCards = await _context.SpaceshipCards.ToListAsync(); //TODO: This has so low performance, figure out other way to choose random cards for players; stored procedure will be better
            IEnumerable<Player> thePlayers = await _context.Players.Take(request.PlayersCount).ToListAsync();

            for (int i = 0; i < request.PlayersCount; i++)
            {
                var spaceshipCards = allSpaceShipCards.OrderBy(x => Guid.NewGuid()).Take(PlayerStatics.MaxHandCards).ToList();
                spaceshipCards.ForEach(x => cards.Add(new SpaceshipCard { Id = x.Id, CardType = x.CardType, CrewCount = x.CrewCount, Name = x.Name, Player = thePlayers.ElementAt(i) }));
            }

            return new GetStartSpaceshipCardResponseModel { Cards = cards };
        }
    }
}
