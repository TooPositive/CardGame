using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Models.Cards
{
    public class Enums
    {
        public enum CardType
        {
            Person,
            Spaceship
        }

        public enum CardResponseResult
        {
            Win,
            Draw,
            NotEnoughCards,
            TooMuchCards
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
