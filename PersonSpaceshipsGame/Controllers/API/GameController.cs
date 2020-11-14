using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonSpaceshipsGame.Controllers.CardGame;
using PersonSpaceshipsGame.Controllers.CardGame.Responses;
using PersonSpaceshipsGame.CQRS.Requests.Cards;
using PersonSpaceshipsGame.CQRS.Requests.Persons;
using PersonSpaceshipsGame.CQRS.Requests.Players;
using PersonSpaceshipsGame.CQRS.Requests.Spaceships;
using PersonSpaceshipsGame.Dtos;
using PersonSpaceshipsGame.Models;
using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;

namespace PersonSpaceshipsGame.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly ICardGameController _cardGameController;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GameController(ILogger<GameController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _cardGameController = new CardGameController(); // change to factory
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all card types
        /// </summary>
        /// <returns>The list of CardTypeDto's</returns>
        /// <remarks>
        /// Sample output:
        /// 
        ///      [
        ///       {
        ///         "name": "Person"
        ///       },
        ///       {
        ///         "name": "Spaceship"
        ///       }
        ///      ]
        /// </remarks>
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<CardTypeDto> GetCardTypes()
        {
            var response = _mediator.Send(request: new GetCardTypesRequestModel());
            return response.Result.CardTypes;
        }

        /// <summary>
        /// Gets starting cards acording to send CardType ( Person or Spaceship ) 
        /// </summary>
        /// <remarks>
        /// Sample response like:
        /// 
        ///         [
        ///            {
        ///              "id": "32dc22ed-c7c1-4d69-9b05-667484824ab4",
        ///              "mass": 70,
        ///              "name": "Loud Person",
        ///              "cardTypeString": "Person",
        ///              "cardType": 0,
        ///              "player": {
        ///                "id": "09d9b6ee-03d8-4d92-b974-44c8c2189a7c",
        ///                "points": 23,
        ///                "cards": null
        ///              }
        ///          },
        ///            {
        ///              "id": "b5378c90-caa6-41e1-ab4d-1dd624fc401e",
        ///              "mass": 35,
        ///              "name": "Popular Person",
        ///              "cardTypeString": "Person",
        ///              "cardType": 0,
        ///              "player": {
        ///                  "id": "09d9b6ee-03d8-4d92-b974-44c8c2189a7c",
        ///                "points": 23,
        ///                "cards": null
        ///              }
        ///          },
        ///            {
        ///              "id": "fca28765-d903-4ced-9453-904aa02be26a",
        ///              "mass": 55,
        ///              "name": "Pretty Person",
        ///              "cardTypeString": "Person",
        ///              "cardType": 0,
        ///              "player": {
        ///                  "id": "09d9b6ee-03d8-4d92-b974-44c8c2189a7c",
        ///                "points": 23,
        ///                "cards": null
        ///              }
        ///          },
        ///            {
        ///              "id": "083faa7b-1fda-4dac-ba09-14a63857f1d9",
        ///              "mass": 1,
        ///              "name": "Funny Person",
        ///              "cardTypeString": "Person",
        ///              "cardType": 0,
        ///              "player": {
        ///                  "id": "2dd5aae4-7fb3-4d6a-a679-7c971466f1bb",
        ///                "points": 17,
        ///                "cards": null
        ///              }
        ///          },
        ///            {
        ///              "id": "fca28765-d903-4ced-9453-904aa02be26a",
        ///              "mass": 55,
        ///              "name": "Pretty Person",
        ///              "cardTypeString": "Person",
        ///              "cardType": 0,
        ///              "player": {
        ///                  "id": "2dd5aae4-7fb3-4d6a-a679-7c971466f1bb",
        ///                "points": 17,
        ///                "cards": null
        ///              }
        ///          },
        ///            {
        ///              "id": "58e9c1f8-6017-49cb-a07f-0cdf82efa01d",
        ///              "mass": 25,
        ///              "name": "Brave Person",
        ///              "cardTypeString": "Person",
        ///              "cardType": 0,
        ///              "player": {
        ///                  "id": "2dd5aae4-7fb3-4d6a-a679-7c971466f1bb",
        ///                "points": 17,
        ///                "cards": null
        ///              }
        ///          }
        ///          ]
        /// </remarks>
        /// <param name="cardType"></param>
        /// <returns>List of playable cards</returns>
        [HttpGet]
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

        /// <summary>
        /// Posting players round cards
        /// </summary>
        /// <remarks>
        /// Sample respone like:
        /// 
        ///      {
        ///        "winner": {
        ///          "id": "09d9b6ee-03d8-4d92-b974-44c8c2189a7c",
        ///          "points": 1,
        ///          "cards": null
        ///        },
        ///        "result": 0
        ///      }
        /// </remarks>
        /// <param name="cards"></param>
        /// <returns>CardsPlayedResponseDto which has round result and winner player object</returns>
        [HttpPost]
        [Route("[action]")]
        public CardsPlayedResponseDto PostRoundPlayedCards([FromBody] PlayableCardDto[] cards)
        {
            //TODO: better error handling
            if (cards.Select(x => x.CardType).Distinct().Count() != 1)
                return null;

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

            if (response.Winner != null)
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
