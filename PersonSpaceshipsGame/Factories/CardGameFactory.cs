using PersonSpaceshipsGame.Controllers.CardGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Factories
{
    public class CardGameFactory
    {
        public static T Create<T>()
        {
            if (typeof(T) == typeof(ICardGameController))
            {
                return (T)(ICardGameController)new CardGameController();
            }
            else
            {
                throw new NotImplementedException(String.Format("Creation of {0} interface is not supported yet.", typeof(T)));
            }
        }
    }
}
