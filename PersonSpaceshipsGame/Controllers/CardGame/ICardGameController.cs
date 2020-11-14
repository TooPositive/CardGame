﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Controllers.CardGame
{
    public interface ICardGameController : IDefaultCardGameController, IPersonsPlayedCardGameController, ISpaceShipsPlayedCardGameController
    {
        
    }
}
