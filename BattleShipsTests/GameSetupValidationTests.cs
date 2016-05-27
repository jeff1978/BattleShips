using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using NUnit.Framework;
using System;

namespace BattleShipsTests
{
    [TestFixture]
    public class GameSetupParserTests
    {
        [Test]
        public void SetValidNumberOfPlayers()
        {
            // arrange
            string inputString1 = "2";
            string inputString2 = "20";
            int expected1 = 2;
            int expected2 = 20;

            // act
            IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
            var inputPlayerTest1 = new GameSetupParser(thisReader1);
            var actual1 = inputPlayerTest1.SetNumberOfPlayers();

            IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
            var inputPlayerTest2 = new GameSetupParser(thisReader2);
            var actual2 = inputPlayerTest2.SetNumberOfPlayers();

            // assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }
        [Test]
        public void SetValidNumberOfShips()
        {
            // arrange
            string inputString1 = "0";
            string inputString2 = "10";

            int expected1 = 0;
            int expected2 = 10;

            // act
            IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
            var inputShipTest1 = new GameSetupParser(thisReader1);
            var actual1 = inputShipTest1.SetNumberOfShips();

            IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
            var inputShipTest2 = new GameSetupParser(thisReader2);
            var actual2 = inputShipTest2.SetNumberOfShips();

            // assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [Test]
        public void SetInvalidNumberOfPlayers()
        {
            // arrange
            string inputString1 = "1";
            string inputString2 = "Jefferson Abraham Williams";

            // act
            IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
            var inputPlayerTest1 = new GameSetupParser(thisReader1);
            inputPlayerTest1.minimumValue = 2;
            inputPlayerTest1.errorMsg = "Invalid number of players entered";
            inputPlayerTest1.processUserInt();

            IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
            var inputPlayerTest2 = new GameSetupParser(thisReader2);
            inputPlayerTest2.minimumValue = 2;
            inputPlayerTest2.errorMsg = "Invalid number of players entered";
            inputPlayerTest2.processUserInt();

            // assert
            Assert.IsFalse(inputPlayerTest1.isValidInput);
            Assert.IsFalse(inputPlayerTest2.isValidInput);
        }

        [Test]
        public void SetInValidNumberOfShips()
        {
            // arrange
            string inputString1 = "-5";
            string inputString2 = "Tony Soprano";

            // act
            IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
            var inputPlayerTest1 = new GameSetupParser(thisReader1);
            inputPlayerTest1.minimumValue = 0;
            inputPlayerTest1.errorMsg = "Invalid number of ships entered";
            inputPlayerTest1.processUserInt();

            IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
            var inputPlayerTest2 = new GameSetupParser(thisReader2);
            inputPlayerTest2.minimumValue = 0;
            inputPlayerTest2.errorMsg = "Invalid number of ships entered";
            inputPlayerTest2.processUserInt();

            // assert
            Assert.IsFalse(inputPlayerTest1.isValidInput);
            Assert.IsFalse(inputPlayerTest2.isValidInput);
        }

        [Test]
        public void SetValidGameMode()
        {
            // arrange
            string inputString1 = "0";
            string inputString2 = "1";
            GameMode expected1 = GameMode.Default;
            GameMode expected2 = GameMode.Custom;

            // act
            IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
            var inputModeTest1 = new GameSetupParser(thisReader1);
            var actual1 = inputModeTest1.SelectGameMode();

            IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
            var inputModeTest2 = new GameSetupParser(thisReader2);
            var actual2 = inputModeTest2.SelectGameMode();

            // assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }
        [Test]
        public void SetInvalidGameMode()
        {
            // arrange
            string inputString1 = "-1";
            string inputString2 = "Gus Fring";

            // act
            IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
            var inputModeTest1 = new GameSetupParser(thisReader1);
            inputModeTest1.processUserModeInput(Enum.GetValues(typeof(GameMode)).Length);

            IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
            var inputModeTest2 = new GameSetupParser(thisReader2);
            inputModeTest2.processUserModeInput(Enum.GetValues(typeof(GameMode)).Length);

            // assert
            Assert.IsFalse(inputModeTest1.isValidInput);
            Assert.IsFalse(inputModeTest2.isValidInput);
        }
    }
}