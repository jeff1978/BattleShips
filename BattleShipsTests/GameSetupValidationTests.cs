using BattleShips.ConsoleChecker;
using NUnit.Framework;
using System;

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
                var newTest1 = new GameSetupValidation(thisReader1);
                var actual1 = newTest1.setNoOfPlayers();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var newTest2 = new GameSetupValidation(thisReader2);
                var actual2 = newTest2.setNoOfPlayers();

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
                var newTest1 = new GameSetupValidation(thisReader1);
                var actual1 = newTest1.setNoOfShips();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var newTest2 = new GameSetupValidation(thisReader2);
                var actual2 = newTest2.setNoOfShips();

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
                var newTest1 = new GameSetupValidation(thisReader1);
                var actual1 = newTest1.setNoOfPlayers();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var newTest2 = new GameSetupValidation(thisReader2);
                var actual2 = newTest2.setNoOfPlayers();

                // assert
                Assert.AreEqual(expected1, actual1);
                Assert.AreEqual(expected2, actual2);
            }
            [Test]
            public void SetInvalidNumberOfShips()
            {
                // arrange
                string inputString1 = "-1";
                string inputString2 = "Sasha Kirsty Williams";

                int expected1 = 1;
                int expected2 = 1;

                // act
                IConsoleReader thisReader1 = new MockConsoleReader(inputString1);
                var newTest1 = new GameSetupValidation(thisReader1);
                var actual1 = newTest1.setNoOfShips();

                IConsoleReader thisReader2 = new MockConsoleReader(inputString2);
                var newTest2 = new GameSetupValidation(thisReader2);
                var actual2 = newTest2.setNoOfShips();

                // assert
                Assert.AreEqual(expected1, actual1);
                Assert.AreEqual(expected2, actual2);
            }
        }
    }
}