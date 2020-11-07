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
        public Guid Id { get; set; }
        public int Points { get; set; }
        public IEnumerable<IPlayableCard> Cards { get; set; }

        public BasePlayer()
        {
            Id = Guid.NewGuid();
            Points = 0;
        }
    }
}
