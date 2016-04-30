using BattleShips.ConsoleChecker;
using NUnit.Framework;

namespace BattleShipsTests
{
    [TestFixture]
    public class InputParserTests
    {
        private readonly IInputParser thisInterface;

        public InputParserTests(IInputParser anyInterface)
        {
            thisInterface = anyInterface;
        }
        public InputParserTests() { }

        [Test]
        public void CheckValidNoOfShips()
        {
            // arrange
            // act
            var thisMock = new InputMock(3);
            var thisTestClass = new InputParserTests(thisMock);
            thisTestClass.thisInterface.getUserInput(RequestType.SetNoOfShips);
            var expected = thisTestClass.thisInterface.noOfShips;

            // assert
            Assert.AreEqual(3, expected);
        }
    }
}