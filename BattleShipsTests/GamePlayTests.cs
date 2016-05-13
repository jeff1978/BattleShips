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
            var placePosition1 = new Position(2, 3);
            var placePosition2 = new Position(7, 2);
            var thisShip1 = new Ship(ShipType.Battleship, true);
            var thisShip2 = new Ship(ShipType.Submarine, false);
            var alivePlayer = new Player();
            var tempList = new List<Ship>();
            var thisGamePlay = new GamePlay();

            // act
            thisShip1.SetShipPositions(placePosition1);
            thisShip2.ShipPostions = thisShip2.GetShipPositions(placePosition2);
            tempList.Add(thisShip1); // floating ship
            tempList.Add(thisShip2); // sunk ship
            alivePlayer.PlayerShips = tempList;

            var deadPlayer = alivePlayer;
            var tempList2 = deadPlayer.PlayerShips;
            tempList2.RemoveAt(0); // remove floating ship
            deadPlayer.PlayerShips = tempList2;

            // add the two players to a list
            var tempList3 = new List<Player>();
            tempList3.Add(alivePlayer);
            tempList3.Add(deadPlayer);
            thisGamePlay.playerList = tempList3;

            // test the method
            thisGamePlay.UpdatePlayerList();

            // assert
            Assert.AreEqual(2, tempList3.Count);
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
    }
}