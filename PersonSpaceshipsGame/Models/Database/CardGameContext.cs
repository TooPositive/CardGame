using Microsoft.EntityFrameworkCore;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Services.CardGameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Models.Database
{
    public class CardGameContext : DbContext
    {
        public CardGameContext(DbContextOptions<CardGameContext> options) : base(options)
        {
            this.Database.Migrate();
        }

        public DbSet<PersonCard> PersonCards { get; set; }
        public DbSet<SpaceshipCard> SpaceshipCards { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
