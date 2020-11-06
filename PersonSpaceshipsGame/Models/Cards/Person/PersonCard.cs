using PersonSpaceshipsGame.Models.Players;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Models.Cards.Person
{
    public class PersonCard : IPersonCard
    {
        #region Properties
        public Guid Id { get; set; }
        public float Mass { get; set; }        
        public string Name { get; set; }
        public Enums.CardType CardType { get; set; } = Enums.CardType.Person;
        public Player Player { get; set; }
        #endregion


        public PersonCard(string json)
        {

        }

        public PersonCard(Guid id, float mass, string name, Player player)
        {
            Id = id;
            Mass = mass;
            Name = name;
            Player = player;
        }

        public int CompareTo(IPersonCard other)
        {
            if (this.Mass < other.Mass)
                return -1;
            if (this.Mass == other.Mass)
                return 0;
            return 1;
        }
    }
}
