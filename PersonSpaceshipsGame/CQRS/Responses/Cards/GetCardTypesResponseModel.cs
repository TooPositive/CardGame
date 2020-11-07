using PersonSpaceshipsGame.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Responses.Cards
{
    public class GetCardTypesResponseModel
    {
        public IEnumerable<CardTypeDto> CardTypes { get; set; }
    }
}
