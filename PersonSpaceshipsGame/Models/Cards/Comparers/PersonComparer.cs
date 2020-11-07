using PersonSpaceshipsGame.Models.Cards.Person;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Models.Cards.Comparers
{
    public class PersonComparer : IComparer<IPersonCard>
    {
        public int Compare([AllowNull] IPersonCard card1, [AllowNull] IPersonCard card2)
        {
            return card1.CompareTo(card2);
        }
    }
}
