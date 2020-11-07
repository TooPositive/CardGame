using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using PersonSpaceshipsGame.Controllers.CardGame;
using PersonSpaceshipsGame.CQRS.Requests.Cards;
using PersonSpaceshipsGame.CQRS.Requests.Persons;
using PersonSpaceshipsGame.Dtos;
using PersonSpaceshipsGame.Factories;
using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using PersonSpaceshipsGame.Services.Interfaces;

namespace PersonSpaceshipsGame.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly CardGameController _cardGameController;
        private readonly IMediator _mediator;

        public GameController(ILogger<GameController> logger, IMediator mediator)
        {
            _logger = logger;
            _cardGameController = new CardGameController(); // change to factory
            _mediator = mediator;
        }

        [Route("[action]")]
        public HttpResponseMessage GetAllPersonCards([FromBody] PlayedCards playedCards)
        {
            var response = _mediator.Send(request: new GetPersonsRequestModel { PersonIds = new List<Guid> { playedCards.Card1Id, playedCards.Card2Id } });
            IEnumerable<IPersonCard> cards = response.Result.PersonCards;
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        [Route("[action]")]
        public  IEnumerable<CardTypeDto> GetCardTypes()
        {
            var response = _mediator.Send(request: new GetCardTypesRequestModel());
            return response.Result.CardTypes;
        }
        
        [HttpPost]
        [Route("[action]")]
        public HttpResponseMessage PostEndOfCardRound([FromBody] PlayedCards cards)
        {

            var response = _mediator.Send(request: new GetPersonsRequestModel { PersonIds = new List<Guid> { cards.Card1Id, cards.Card2Id } });
            //var response = cardGameController.CardsPlayed(cards);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}
