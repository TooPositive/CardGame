using MediatR;
using PersonSpaceshipsGame.CQRS.Responses.Spaceships;
using PersonSpaceshipsGame.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Requests.Spaceships
{
    public class GetStartSpaceshipCardRequestModel : IRequest<GetStartSpaceshipCardResponseModel>
    {
        public int PlayersCount { get; set; } = PlayerStatics.MaxPlayersCount;
    }
}
