using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonSpaceshipsGame.CQRS.Requests.Players;
using PersonSpaceshipsGame.CQRS.Responses.Players;
using PersonSpaceshipsGame.Models.Database;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Handlers.QueriesHandlers.Players
{
    public class GetAllPlayersQueryHandler : IRequestHandler<GetPlayersRequestModel, GetPlayersResponseModel>
    {
        private readonly CardGameContext _context;
        public GetAllPlayersQueryHandler(CardGameContext context)
        {
            _context = context;
        }

        public async Task<GetPlayersResponseModel> Handle(GetPlayersRequestModel request, CancellationToken cancellationToken)
        {
            System.Collections.Generic.List<Models.Player> players = await _context.Players.Where(x => request.Guids.Contains(x.Id)).ToListAsync();

            return new GetPlayersResponseModel { Players = players };
        }
    }
}
