using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.CQRS.Responses.Persons
{
    public class PostPlayerChangesResponseModel
    {
        public bool IsSuccess { get; set; }
    }
}
