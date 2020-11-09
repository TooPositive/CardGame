using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonSpaceshipsGame.CQRS.Requests.Persons;
using PersonSpaceshipsGame.CQRS.Responses.Persons;
using PersonSpaceshipsGame.Models;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Database;
using PersonSpaceshipsGame.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Handlers.QueriesHandlers.Persons
{
    //TODO: this should be one query with Spaceships query handler
    public class GetStartPersonsCardQueryHandler : IRequestHandler<GetStartPersonsCardRequestModel, GetStartPersonsCardResponseModel>
    {
        private readonly CardGameContext _context;
        public GetStartPersonsCardQueryHandler(CardGameContext context)
        {
            _context = context;
        }

        public async Task<GetStartPersonsCardResponseModel> Handle(GetStartPersonsCardRequestModel request, CancellationToken cancellationToken)
        {
            List<PersonCard> cards = new List<PersonCard>();
            List<PersonCard> allPersonCards = await _context.PersonCards.ToListAsync(); //TODO: This has so low performance, figure out other way to choose random cards for players; stored procedure will be better            
            IEnumerable<Player> thePlayers = await _context.Players.Take(request.PlayersCount).ToListAsync();

            for (int i = 0; i < request.PlayersCount; i++)
            {
                var personCards = allPersonCards.OrderBy(x => Guid.NewGuid()).Take(PlayerStatics.MaxHandCards).ToList();
                var thePlayer = thePlayers.ElementAt(i);
                personCards.ForEach(x => cards.Add(new PersonCard {Id = x.Id, CardType = x.CardType, Mass = x.Mass, Name = x.Name , Player = thePlayers.ElementAt(i) })); //TODO: store players in DB
            }

            return new GetStartPersonsCardResponseModel { Cards = cards };
        }
    }
}
