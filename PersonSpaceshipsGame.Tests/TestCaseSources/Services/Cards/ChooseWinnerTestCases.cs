using NUnit.Framework;
using PersonSpaceshipsGame.Models;
using PersonSpaceshipsGame.Models.Cards.Person;
using PersonSpaceshipsGame.Models.Cards.Spaceships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonSpaceshipsGame.Tests.TestCaseSources.Services.Cards
{
    public class ChooseWinnerTestCases
    {
        public static IEnumerable<TestCaseData> PersonTestCases
        {
            get
            {
                IPersonCard mass10PersonCard = new PersonCard(new Guid(), 10, "Mass 10", new Player());
                IPersonCard mass15PersonCard = new PersonCard(new Guid(), 15, "Mass 15", new Player());

                yield return new TestCaseData(mass15PersonCard, mass10PersonCard, mass15PersonCard);
                yield return new TestCaseData(mass15PersonCard, mass15PersonCard, null);
            }
        }

        public static IEnumerable<TestCaseData> SpaceshipsTestCases
        {
            get
            {
                ISpaceshipCard crewCount10PersonCard = new SpaceshipCard(new Guid(), 10, "CrewCount 10", new Player());
                ISpaceshipCard crewCount15PersonCard = new SpaceshipCard(new Guid(), 15, "CrewCount 15", new Player());

                yield return new TestCaseData(crewCount15PersonCard, crewCount10PersonCard, crewCount15PersonCard);
                yield return new TestCaseData(crewCount15PersonCard, crewCount15PersonCard, null);
            }
        }
    }
}
