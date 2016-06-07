using BattleShips;
using BattleShips.BattleGround;
using BattleShips.BShip;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipsTest
{
        [TestFixture]
        public class ShipTests
        {
            [Test]
            public void CheckIsShipFloating()
            {
            // arrange
            // ship 1. has all floating positions
            // ship 2. has some floating positions
            // ship 3. has no floating positions
            var placePosition = new Position(2, 3);
            var thisShip1 = new Ship(ShipType.Battleship, true);
            var thisShip2 = new Ship(ShipType.Submarine, false);
            var thisShip3 = new Ship(ShipType.Destroyer, false);

            // set all ships afloat
            thisShip1.SetShipPositions(placePosition);
            thisShip2.SetShipPositions(placePosition);
            thisShip3.SetShipPositions(placePosition);

            // damage the second ship
            thisShip2.ShipPositions[2].IsFloating = false;

            // sink the third ship
            thisShip3.ShipPositions[0].IsFloating = false;
            thisShip3.ShipPositions[1].IsFloating = false;

            // act and assert
            Assert.IsTrue(thisShip1.IsShipFloating());
            Assert.IsTrue(thisShip2.IsShipFloating());
            Assert.IsFalse(thisShip3.IsShipFloating());
        }

        [Test]
        public void CheckIsPlayerAlive()
        {
            // arrange
            // set up the test with two initialised players
            // set one of the players to alive and the other to dead

            // act

            // setup alive player scenario
            var placePosition = new Position(7, 2);
            var thisShip1 = new Ship(ShipType.Battleship, true);
            var thisShip2 = new Ship(ShipType.Submarine, false);
            var alivePlayer = new Player();
            var tempList = new List<Ship>();

            thisShip1.SetShipPositions(placePosition);
            thisShip2.SetShipPositions(placePosition);
            thisShip2.ShipPositions.ForEach(p => p.IsFloating = false);
                
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
            thisShip3.ShipPositions.ForEach(p => p.IsFloating = false);
            thisShip4.ShipPositions.ForEach(p => p.IsFloating = false);

            tempList2.Add(thisShip3); // sunk ship
            tempList2.Add(thisShip4); // sunk ship
            deadPlayer.PlayerShips = tempList2;
    
            // assert
            Assert.IsTrue(alivePlayer.IsPlayerAlive());
            Assert.IsFalse(deadPlayer.IsPlayerAlive());
        }

        [Test]
        public void CheckGetFloatingShips()
        {
            // arrange
            // set a ship list with just 3 ships.
            // ship 1. has all floating positions
            // ship 2. has some floating positions
            // ship 3. has no floating positions
            var placePosition1 = new Position(2, 3);
            var placePosition2 = new Position(7, 2);
            var placePosition3 = new Position(5, 1);
            var thisShip1 = new Ship(ShipType.Battleship, true);
            var thisShip2 = new Ship(ShipType.Submarine, false);
            var thisShip3 = new Ship(ShipType.Destroyer, false);

            // set all ships afloat
            thisShip1.SetShipPositions(placePosition1);
            thisShip2.SetShipPositions(placePosition2);
            thisShip3.SetShipPositions(placePosition3);

            // damage the second ship
            thisShip2.ShipPositions[2].IsFloating = false;

            // sink the third ship
            thisShip3.ShipPositions[0].IsFloating = false;
            thisShip3.ShipPositions[1].IsFloating = false;

            // add all ships to list then test
            var shipList = new List<Ship>() { thisShip1, thisShip2, thisShip3};

            // act
            var thisPlayer = new Player();
            thisPlayer.PlayerShips = shipList;
            var floatingShips = thisPlayer.GetFloatingShips();

            // assert
            // check the floating status of each ship
            Assert.IsTrue(thisShip1.IsShipFloating());
            Assert.IsTrue(thisShip2.IsShipFloating());
            Assert.IsFalse(thisShip3.IsShipFloating());
            // check only two ships returned
            Assert.AreEqual(2, floatingShips.Count());
            // check all 3 positions for ship 1 are floating
            Assert.IsTrue(floatingShips[0].ShipPositions[0].IsFloating);
            Assert.IsTrue(floatingShips[0].ShipPositions[1].IsFloating);
            Assert.IsTrue(floatingShips[0].ShipPositions[2].IsFloating);
            // check for one sunk position in ship 2
            Assert.IsFalse(floatingShips[1].ShipPositions[2].IsFloating);
        }
    }
}