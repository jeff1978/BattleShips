using BattleShips;
using BattleShips.BattleGround;
using BattleShips.BShip;
using NUnit.Framework;
using System.Collections.Generic;

namespace BattleShipsTests
{
    [TestFixture]
    public class GamePlayTests
    {
        [Test]
        public void CheckUpdatePlayerList()
        {
            // arrange
            // set up the test with two initialised players, one alive and the other dead
            // add both players to an instance of the gameplay class then test the method
            // act

            // setup alive player scenario
            var placePosition = new Position(7, 2);
            var thisShip1 = new Ship(ShipType.Battleship, true);
            var thisShip2 = new Ship(ShipType.Submarine, false);
            var alivePlayer = new Player();
            var tempList = new List<Ship>();

            thisShip1.SetShipPositions(placePosition);
            thisShip2.SetShipPositions(placePosition);
            thisShip2.ShipPostions.ForEach(p => p.IsFloating = false);

            tempList.Add(thisShip1); // floating ship
            tempList.Add(thisShip2); // sunk ship
            alivePlayer.PlayerShips = tempList;

            // setup dead player scenario
            var thisShip3 = new Ship(ShipType.Battleship, true);
            var thisShip4 = new Ship(ShipType.Submarine, false);
            var deadPlayer = new Player();
            var tempList2 = new List<Ship>();

            thisShip3.SetShipPositions(placePosition);
            thisShip4.SetShipPositions(placePosition);
            thisShip3.ShipPostions.ForEach(p => p.IsFloating = false);
            thisShip4.ShipPostions.ForEach(p => p.IsFloating = false);

            tempList2.Add(thisShip3); // sunk ship
            tempList2.Add(thisShip4); // sunk ship
            deadPlayer.PlayerShips = tempList2;

            // add the two players to a list
            var tempList3 = new List<Player>();
            tempList3.Add(alivePlayer);
            tempList3.Add(deadPlayer);
            var expectedCountNotUpdated = tempList3.Count;

            // add the list to the game play property
            var thisGamePlay = new GamePlay();
            thisGamePlay.playerList = tempList3;

            // test the method
            thisGamePlay.UpdatePlayerList();

            // assert
            Assert.AreEqual(2, expectedCountNotUpdated);
            Assert.AreEqual(1, thisGamePlay.playerList.Count);
        }

        [Test]
        public void CheckForWinner()
        {
            // arrange
            // set up the test to check two lists, the first has only one player,
            // the other list has two players so should return false.
            var player1 = new Player();
            player1.PlayerName = "Saul Goodman";
            var player2 = new Player();
            player1.PlayerName = "Frank Underwood";

            var winList = new List<Player>();
            winList.Add(player1);

            var noWinList = new List<Player>();
            noWinList.Add(player1);
            noWinList.Add(player2);

            // act
            var thisGamePlay1 = new GamePlay();
            thisGamePlay1.playerList = winList;

            var thisGamePlay2 = new GamePlay();
            thisGamePlay2.playerList = noWinList;

            // assert
            Assert.IsTrue(thisGamePlay1.CheckForWinner());
            Assert.IsFalse(thisGamePlay2.CheckForWinner());
        }

        [Test]
        public void CheckGetEnemyPlayers()
        {
            // arrange
            // create three players and add them to a list
            // then pass one of the players as a parameter to
            // GetEnemyPlayers() and check the result
            var player1 = new Player();
            player1.PlayerName = "Saul Goodman";
            var player2 = new Player();
            player2.PlayerName = "Frank Underwood";
            var player3 = new Player();
            player3.PlayerName = "Eric Benet";

            var thisList = new List<Player>();
            thisList.Add(player1);
            thisList.Add(player2);
            thisList.Add(player3);

            // act
            var thisGamePlay1 = new GamePlay();
            thisGamePlay1.playerList = thisList;

            var resultList = thisGamePlay1.GetEnemyPlayers(player2);

            // assert
            Assert.AreEqual("Saul Goodman", resultList[0].PlayerName);
            Assert.AreEqual("Eric Benet", resultList[1].PlayerName);
        }
    }
}