using PersonSpaceshipsGame.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Models.Players
{
    public abstract class BasePlayer
    {
        public int Points { get; set; }
        public ICollection<IPlayableCard> Cards { get; set; }
    }
}
