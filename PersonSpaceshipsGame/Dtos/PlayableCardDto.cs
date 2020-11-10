using PersonSpaceshipsGame.Models;
using static PersonSpaceshipsGame.Models.Cards.Enums;

namespace PersonSpaceshipsGame.Dtos
{
    public class PlayableCardDto
    {
        public CardType CardType { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public Player player { get; set; }
    }
}
