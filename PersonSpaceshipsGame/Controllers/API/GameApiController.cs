using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using PersonSpaceshipsGame.Controllers.CardGame;
using PersonSpaceshipsGame.Dtos;
using PersonSpaceshipsGame.Factories;
using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using PersonSpaceshipsGame.Services.Interfaces;

namespace PersonSpaceshipsGame.Controllers.API
{
    [ApiController]
    [Route("[controller]")]
    public class GameApiController : ControllerBase
    {
       
        private readonly ILogger<GameApiController> _logger;
        private readonly ICardGameController cardGameController;

        public GameApiController(ILogger<GameApiController> logger, ICardGameController cardGameController)
        {
            _logger = logger;
            this.cardGameController = cardGameController;
        }

        [HttpPost]
        public HttpResponseMessage PostEndOfCardRound([FromBody] PlayedCards cards)
        {

            var response = cardGameController.CardsPlayed(cards);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}
