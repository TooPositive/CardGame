using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Factories
{
    public class CardFactory
    {

        public static Type GetPlayedCardType(Enums.CardType cardType)
        {
            switch (cardType)
            {
                case Enums.CardType.Person:
                    return typeof(IPersonCard);
                case Enums.CardType.Spaceship:
                    return typeof(ISpaceshipCard);
                default:
                    throw new NotImplementedException(String.Format($"Cannot find interface for card type {cardType}"));
            }
        }

        public static T Create<T>(string playedCard)
        {
            if (typeof(T) == typeof(IPersonCard))
            {
                return (T)(IPersonCard)new PersonCard(playedCard);
            }
            else
            {
                throw new NotImplementedException(String.Format("Creation of {0} interface is not supported yet.", typeof(T)));
            }
        }
    }
}
