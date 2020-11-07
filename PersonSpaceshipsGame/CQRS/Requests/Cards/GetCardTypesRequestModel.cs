using MediatR;
using PersonSpaceshipsGame.CQRS.Responses.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Requests.Cards
{
    public class GetCardTypesRequestModel : IRequest<GetCardTypesResponseModel>
    {
        
    }
}
