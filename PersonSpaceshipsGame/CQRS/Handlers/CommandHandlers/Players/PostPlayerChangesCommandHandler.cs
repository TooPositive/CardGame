using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonSpaceshipsGame.CQRS.Requests.Players;
using PersonSpaceshipsGame.CQRS.Responses.Persons;
using PersonSpaceshipsGame.Models;
using PersonSpaceshipsGame.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Handlers.CommandHandlers.Players
{
    public class PostPlayerChangesCommandHandler : IRequestHandler<PostPlayerChangesRequestModel, PostPlayerChangesResponseModel>
    {
        private readonly CardGameContext _context;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public PostPlayerChangesCommandHandler(CardGameContext context, IServiceScopeFactory serviceScopeFactory)
        {
            _context = context;
            _serviceScopeFactory = serviceScopeFactory;
        }


        //TODO: better error handling
        public async Task<PostPlayerChangesResponseModel> Handle(PostPlayerChangesRequestModel request, CancellationToken cancellationToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetService<CardGameContext>();
                Player player = await _context.Players.FirstOrDefaultAsync(x => x.Id == request.Player.Id);

                if (player == null)
                    return new PostPlayerChangesResponseModel { IsSuccess = false };
                try
                {
                    if (player.Points != request.Player.Points)
                    {
                        player.Points = request.Player.Points;
                        await _context.SaveChangesAsync();
                    }
                }
                catch (Exception)
                {
                    return new PostPlayerChangesResponseModel { IsSuccess = false };
                }
                return new PostPlayerChangesResponseModel { IsSuccess = true };
            }

        }
    }
}
