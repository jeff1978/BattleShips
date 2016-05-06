using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using NUnit.Framework;

namespace BattleShipsTests
{
    public class testClass
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
                var inputPlayerTest1 = new GameSetupValidation(thisReader1);
                var actual1 = inputPlayerTest1.SetNumberOfPlayers();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputPlayerTest2 = new GameSetupValidation(thisReader2);
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
                var inputShipTest1 = new GameSetupValidation(thisReader1);
                var actual1 = inputShipTest1.SetNumberOfShips();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputShipTest2 = new GameSetupValidation(thisReader2);
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
                int expected1 = 2;
                int expected2 = 2;

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputPlayerTest1 = new GameSetupValidation(thisReader1);
                var actual1 = inputPlayerTest1.SetNumberOfPlayers();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputPlayerTest2 = new GameSetupValidation(thisReader2);
                var actual2 = inputPlayerTest2.SetNumberOfPlayers();

                // assert
                Assert.AreEqual(expected1, actual1);
                Assert.AreEqual(expected2, actual2);
            }

            [Test]
            public void SetInValidNumberOfShips()
            {
                // arrange
                string inputString1 = "-5";
                string inputString2 = "Tony Soprano";

                int expected1 = 1;
                int expected2 = 1;

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputShipTest1 = new GameSetupValidation(thisReader1);
                var actual1 = inputShipTest1.SetNumberOfShips();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputShipsTest2 = new GameSetupValidation(thisReader2);
                var actual2 = inputShipsTest2.SetNumberOfShips();

                // assert
                Assert.AreEqual(expected1, actual1);
                Assert.AreEqual(expected2, actual2);
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
                var inputModeTest1 = new GameSetupValidation(thisReader1);
                var actual1 = inputModeTest1.SelectGameMode();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputModeTest2 = new GameSetupValidation(thisReader2);
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
                GameMode expected1 = GameMode.Default;
                GameMode expected2 = GameMode.Default;

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputModeTest1 = new GameSetupValidation(thisReader1);
                var actual1 = inputModeTest1.SelectGameMode();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputModeTest2 = new GameSetupValidation(thisReader2);
                var actual2 = inputModeTest2.SelectGameMode();

                // assert
                Assert.AreEqual(expected1, actual1);
                Assert.AreEqual(expected2, actual2);
            }
        }
    }
}