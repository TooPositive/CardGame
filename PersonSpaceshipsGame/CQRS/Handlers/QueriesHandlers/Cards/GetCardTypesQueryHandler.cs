using MediatR;
using PersonSpaceshipsGame.CQRS.Requests.Cards;
using PersonSpaceshipsGame.CQRS.Responses.Cards;
using PersonSpaceshipsGame.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Handlers.QueriesHandlers.Cards
{
    public class GetCardTypesQueryHandler : IRequestHandler<GetCardTypesRequestModel, GetCardTypesResponseModel>
    {
        public async Task<GetCardTypesResponseModel> Handle(GetCardTypesRequestModel request, CancellationToken cancellationToken)
        {
            // TODO: Add this to database
            return new GetCardTypesResponseModel() { CardTypes = new List<CardTypeDto>() { new CardTypeDto() { Name = "Persons" }, new CardTypeDto() { Name = "Spaceships" } } };
        }
    }
}
