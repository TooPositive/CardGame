using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PersonSpaceshipsGame.Controllers.API;
using PersonSpaceshipsGame.Controllers.CardGame;
using PersonSpaceshipsGame.CQRS.Requests.Persons;
using PersonSpaceshipsGame.CQRS.Responses.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Tests.CQRS
{
    public class PersonsTests
    {
        private Mock<IMediator> _mediator;

        public PersonsTests()
        {
            _mediator = new Mock<IMediator>();
        }

        [TestCase]
        public void GetAllPersons_Success()
        {
            //TODO: add mocked tests
            var getAllRequestModel = new GetPersonsRequestModel { PersonIds = new List<Guid> {new Guid()} };
            _mediator.Setup(x => x.Send(It.IsAny<GetPersonsResponseModel>(), new System.Threading.CancellationToken())).ReturnsAsync(new GetPersonsResponseModel());
            //var cardGameController = new GameApiController(null,null,_mediator.Object);
            //var result = cardGameController.CardsPlayed(getAllRequestModel);

            //Assert.IsTrue(result is OkObjectResult);
        }
    }
}
