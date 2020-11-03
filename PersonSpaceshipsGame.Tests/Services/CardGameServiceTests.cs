using NUnit.Framework;
using PersonSpaceshipsGame.Factories;
using PersonSpaceshipsGame.Models.Cards;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using PersonSpaceshipsGame.Services.CardGameService.Interfaces;
using PersonSpaceshipsGame.Tests.TestCaseSources.Services.Cards;

namespace PersonSpaceshipsGame.Tests.Services
{
    public class CardGameServiceTests
    {

        private IPersonCardGameService personCardGameService;
        private ISpaceshipCardGameService spaceshipCardGameService;       

        [SetUp]
        public void Setup()
        {
            this.personCardGameService = GameServiceFactory.Create<IPersonCardGameService>();
            this.spaceshipCardGameService = GameServiceFactory.Create<ISpaceshipCardGameService>();
        }

        //[Test]
        [TestCaseSource(typeof(ChooseWinnerTestCases), nameof(ChooseWinnerTestCases.PersonTestCases))]
        public void ChooseWinnerPersonCard(IPersonCard card1, IPersonCard card2, IPersonCard? winnerCard)
        {
            IPlayableCard? winnerCardfromService = personCardGameService.ChooseWinnerCard(card1, card2);
            Assert.AreEqual(winnerCardfromService, winnerCard);
        }

        [TestCaseSource(typeof(ChooseWinnerTestCases), nameof(ChooseWinnerTestCases.SpaceshipsTestCases))]
        public void ChooseWinnerSpaceshipCard(ISpaceshipCard card1, ISpaceshipCard card2, ISpaceshipCard? winnerCard)
        {
            ISpaceshipCard? winnerCardfromService = spaceshipCardGameService.ChooseWinnerCard(card1, card2);
            Assert.AreEqual(winnerCardfromService, winnerCard);
        }
    }
}
