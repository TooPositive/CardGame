using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Models.Cards.Person
{
    public class PersonCard : IPersonCard
    {
        public int Id { get; set; }
        public float Mass { get; set; }        
        public string Name { get; set; }

        public PersonCard(int id, float mass, string name)
        {
            Id = id;
            Mass = mass;
            Name = name;
        }

        public PersonCard(string json)
        {

        }
    }
}
