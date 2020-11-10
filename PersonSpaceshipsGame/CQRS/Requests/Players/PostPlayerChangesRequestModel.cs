using MediatR;
using PersonSpaceshipsGame.CQRS.Responses.Persons;
using PersonSpaceshipsGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Requests.Players
{
    public class PostPlayerChangesRequestModel : IRequest<PostPlayerChangesResponseModel>
    {
        public Player Player { get; set; }
    }
}
