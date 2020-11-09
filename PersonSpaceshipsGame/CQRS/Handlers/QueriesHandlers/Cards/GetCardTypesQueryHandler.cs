using MediatR;
using PersonSpaceshipsGame.CQRS.Requests.Cards;
using PersonSpaceshipsGame.CQRS.Responses.Cards;
using PersonSpaceshipsGame.Dtos;
using PersonSpaceshipsGame.Models.Cards;
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
            List<CardTypeDto> cardTypes = new List<CardTypeDto>();
            Enum.GetValues(typeof(Enums.CardType)).Cast<Enums.CardType>().ToList().ForEach(x => cardTypes.Add(new CardTypeDto { Name = x.ToString()}));
            return new GetCardTypesResponseModel() { CardTypes = cardTypes };
        }
    }
}