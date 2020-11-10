using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using PersonSpaceshipsGame.Controllers.CardGame;
using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.CQRS.Requests.Cards;
using PersonSpaceshipsGame.CQRS.Requests.Persons;
using PersonSpaceshipsGame.CQRS.Requests.Players;
using PersonSpaceshipsGame.CQRS.Requests.Spaceships;
using PersonSpaceshipsGame.Dtos;
using PersonSpaceshipsGame.Factories;
using PersonSpaceshipsGame.Models;
using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
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
        private readonly IMapper _mapper;

        public GameController(ILogger<GameController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _cardGameController = new CardGameController(); // change to factory
            _mediator = mediator;
            _mapper = mapper;
        }

        [Route("[action]")]
        public HttpResponseMessage GetAllPersonCards([FromBody] PlayedCards playedCards)
        {
            var response = _mediator.Send(request: new GetPersonsRequestModel { PersonIds = new List<Guid> { playedCards.Card1Id, playedCards.Card2Id } });
            IEnumerable<IPersonCard> cards = response.Result.PersonCards;
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }

        [Route("[action]")]
        public IEnumerable<CardTypeDto> GetCardTypes()
        {
            var response = _mediator.Send(request: new GetCardTypesRequestModel());
            return response.Result.CardTypes;
        }

        [Route("[action]/{cardType}")]
        public IEnumerable<IPlayableCard> GetStartingGamesCards(Enums.CardType cardType)
        {
            //TODO: change to factory query method
            switch (cardType)
            {
                case Enums.CardType.Person:
                    var personResponse = _mediator.Send(request: new GetStartPersonsCardRequestModel());
                    return personResponse.Result.Cards;
                case Enums.CardType.Spaceship:
                    var spaceshipResponse = _mediator.Send(request: new GetStartSpaceshipCardRequestModel());
                    return spaceshipResponse.Result.Cards;
                default:
                    throw new NotImplementedException($"{cardType} is not implemented for starting game.");
            }
        }

        [HttpPost]
        [Route("[action]")]
        public CardsPlayedResponseDto PostRoundPlayedCards([FromBody] PlayableCardDto[] cards)
        {
            //TODO: better error handling
            if (cards.Select(x => x.CardType).Distinct().Count() != 1)
                return null;

            // Wrong winner assign !!!!

            IEnumerable<Player> players = _mediator.Send(request: new GetPlayersRequestModel { Guids = cards.Select(x => x.player.Id).ToList() }).Result.Players;
            ICardsPlayedResponse response; 

            //TODO: Move logic to cardController and follow open/close principle
            switch (cards.First().CardType)
            {
                case Enums.CardType.Person:
                    response = GetPersonsCardPlayedResponse(cards, players);
                    break;
                case Enums.CardType.Spaceship:
                    response = GetSpaceShipPlayedResponse(cards, players);
                    break;
                default:
                    return null;//TODO: Better error handling
            }

            if(response.Winner != null)
                _mediator.Send(request: new PostPlayerChangesRequestModel { Player = response.Winner });

            return _mapper.Map<CardsPlayedResponseDto>(response);
        }

        //TODO: move this with mediator call to cardgame controller
        private ICardsPlayedResponse GetSpaceShipPlayedResponse(PlayableCardDto[] cards, IEnumerable<Player> players)
        {
            ICardsPlayedResponse response;
            List<ISpaceshipCard> spaceShipCards = new List<ISpaceshipCard>();

            for (int i = 0; i < cards.Length; i++)
            {
                var spaceshipCardsResponse = _mediator.Send(request: new GetSpaceshipRequestModel { SpaceshipIds = new List<Guid> { Guid.Parse(cards[i].id) } }).Result.SpaceshipCards;
                spaceshipCardsResponse.ToList().ForEach(x => x.Player = players.ElementAt(i));
                spaceShipCards.AddRange(spaceshipCardsResponse);
            }

            response = _cardGameController.SpaceShipCardsPlayed(spaceShipCards);
            return response;

        }

        //TODO: move this with mediator call to cardgame controller
        private ICardsPlayedResponse GetPersonsCardPlayedResponse(PlayableCardDto[] cards, IEnumerable<Player> players)
        {
            ICardsPlayedResponse response;
            List<IPersonCard> personCards = new List<IPersonCard>();

            for (int i = 0; i < cards.Length; i++)
            {
                var personCardsResponse = _mediator.Send(request: new GetPersonsRequestModel { PersonIds = new List<Guid> { Guid.Parse(cards[i].id) } }).Result.PersonCards;
                personCardsResponse.ToList().ForEach(x => x.Player = players.ElementAt(i));
                personCards.AddRange(personCardsResponse);
            }

            response = _cardGameController.PersonsCardsPlayed(personCards);
            return response;
        }
    }
}
