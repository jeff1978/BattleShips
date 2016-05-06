using BattleShips.ConsoleChecker;
using BattleShips.Setup;
using NUnit.Framework;
using System;

namespace BattleShipsTests
{
    public class PlayerSetupValidationTests
    {
        [TestFixture]
        public class GameSetupParserTests
        {
            [Test]
            public void SetValidPlayerName()
            {
                // arrange
                string inputString1 = "Jeff";
                string inputString2 = "Sasha";
                string expected1 = "Jeff";
                string expected2 = "Sasha";

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputPlayerTest1 = new PlayerSetupValidation(thisReader1);
                var actual1 = inputPlayerTest1.SetPlayerName();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputPlayerTest2 = new PlayerSetupValidation(thisReader2);
                var actual2 = inputPlayerTest2.SetPlayerName();

                // assert
                Assert.AreEqual(expected1, actual1);
                Assert.AreEqual(expected2, actual2);
            }
            [Test]
            public void SetInvalidPlayerName()
            {
                // arrange
                string inputString1 = null;
                string inputString2 = " ";
                string expected1 = "Unknown";
                string expected2 = "Unknown";

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputPlayerTest1 = new PlayerSetupValidation(thisReader1);
                var actual1 = inputPlayerTest1.SetPlayerName();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputPlayerTest2 = new PlayerSetupValidation(thisReader2);
                var actual2 = inputPlayerTest2.SetPlayerName();

                // assert
                Assert.AreEqual(expected1, actual1);
                Assert.AreEqual(expected2, actual2);
            }

            [Test]
            public void SetValidNewShip()
            {
                // arrange
                string inputString1 = "2,3,h";
                string inputString2 = "5,6,v";
                string expected1 = "2,3,h";
                string expected2 = "5,6,v";

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputPlayerTest1 = new PlayerSetupValidation(thisReader1);
                var actual1 = inputPlayerTest1.PlaceNewShip();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputPlayerTest2 = new PlayerSetupValidation(thisReader2);
                var actual2 = inputPlayerTest2.PlaceNewShip();

                // assert
                Assert.AreEqual(expected1, actual1);
                Assert.AreEqual(expected2, actual2);
            }
            [Test]
            public void SetInvalidNewShip()
            {
                // arrange
                string inputString1 = "2,3,horizontal";
                string inputString2 = "5,six,v";

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputPlayerTest1 = new PlayerSetupValidation(thisReader1);
                var actual1 = inputPlayerTest1.PlaceNewShip();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputPlayerTest2 = new PlayerSetupValidation(thisReader2);
                var actual2 = inputPlayerTest2.PlaceNewShip();

                // assert
                Assert.IsNull(actual1);
                Assert.IsNull(actual2);
            }

            [Test]
            public void FireAtValidCoordinates()
            {
                // arrange
                string inputString1 = "2,3";
                string inputString2 = "33,1";
                string expected1 = "2,3";
                string expected2 = "33,1";

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputFireTest1 = new PlayerSetupValidation(thisReader1);
                var actual1 = inputFireTest1.FireCommand();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputFireTest2 = new PlayerSetupValidation(thisReader2);
                var actual2 = inputFireTest2.FireCommand();

                // assert
                Assert.AreEqual(expected1, actual1);
                Assert.AreEqual(expected2, actual2);
            }

            [Test]
            public void FireAtInvalidCoordinates()
            {
                // arrange
                string inputString1 = "2,";
                string inputString2 = "33,one";

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var inputFireTest1 = new PlayerSetupValidation(thisReader1);
                var actual1 = inputFireTest1.FireCommand();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var inputFireTest2 = new PlayerSetupValidation(thisReader2);
                var actual2 = inputFireTest2.FireCommand();

                // assert
                Assert.IsNull(actual1);
                Assert.IsNull(actual2);
            }
        }
    }
}