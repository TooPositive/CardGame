using PersonSpaceshipsGame.Models.Cards.Spaceships;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Models.Cards.Comparers
{
    public class SpaceShipComparer : IComparer<ISpaceshipCard>
    {
        public int Compare([AllowNull] ISpaceshipCard card1, [AllowNull] ISpaceshipCard card2)
        {
            return card1.CompareTo(card2);
        }
    }
}
