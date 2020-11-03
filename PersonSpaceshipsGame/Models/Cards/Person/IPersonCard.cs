using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Models.Cards.Person
{
    public interface IPersonCard : IPlayableCard
    {
        public float Mass { get; set; }
    }
}
