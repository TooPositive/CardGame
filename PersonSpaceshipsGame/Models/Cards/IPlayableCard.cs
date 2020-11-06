using PersonSpaceshipsGame.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Models.Cards
{
    public interface IPlayableCard
    {
        public Enums.CardType CardType { get; set; }
        Guid Id { get; set; }
        string Name { get; set; }
        public Player Player { get; set; }

    }
}
