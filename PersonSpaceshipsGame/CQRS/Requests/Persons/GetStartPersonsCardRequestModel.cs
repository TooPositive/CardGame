using MediatR;
using PersonSpaceshipsGame.CQRS.Responses.Persons;
using PersonSpaceshipsGame.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Requests.Persons
{
    public class GetStartPersonsCardRequestModel : IRequest<GetStartPersonsCardResponseModel>
    {
        public int PlayersCount { get; set; } = PlayerStatics.MaxPlayersCount;
    }
}
