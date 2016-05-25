using BattleShips.BattleGround;
using BattleShips.BShip;
using BattleShips.ConsoleChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using BattleShips.Properties;
 
namespace BattleShips
{
    /// <summary>
    /// This class handles all the gameplay once the game and the players have been set up.
    /// </summary>
    public class GamePlay : IGamePlay
    {
        private IGamePlayParser thisGamePlayParser = new GamePlayParser();
        public List<Player> playerList { get; set; }
        private bool positionIsHit { get; set; }
        public bool IsGameOver { get; set; }

        public void PlayGame()
        {
            // show the game start message.
            Console.WriteLine(Resources.gameStart);

            IsGameOver = false;
            while (IsGameOver == false)
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    positionIsHit = false;

                    // show fire command message
                    Console.WriteLine(Resources.getFireCommand, playerList[i].PlayerName);

                    // get Position from user for fire command
                    var fireCoordinate = thisGamePlayParser.FireCommand();

                    // process the fire command
                    PlayerTakeTurn(fireCoordinate, playerList[i]);

                    // check if missed !! then show message
                    showMissMessage();

                    // delete any players without floating ships and check for winner
                    UpdatePlayerList();
                    CheckForWinner();
                }
            }
            Console.WriteLine(Resources.gameEndMessage);
            Console.ReadLine();
        }

        private void PlayerTakeTurn(Position firePosition, Player thisPlayer)
        {
            // get a list of players excluding this player:
            var enemies = GetEnemyPlayers(thisPlayer);

            for (int i = 0; i < enemies.Count; i++)
            {
                //get the this enemy's floating ships only and fire at each one!
                var floatingEnemyShips = enemies[i].GetFloatingShips();
                FireCommand(firePosition, floatingEnemyShips);
            }
        }

        private void FireCommand(Position firePosition, List<Ship> floatingEnemyShips)
        {
            foreach (var floatingShip in floatingEnemyShips)
            {
                // get the floating ship positions only
                var floatingPositions = floatingShip.ShipPostions.Where(p => p.IsFloating).ToList();

                // for each floating position compare it to the fire position
                floatingPositions.ForEach(p => comparePositions(firePosition, p, floatingShip));
            }
        }

        // This method compares two positions and where appropriate sets the floating property
        // to false. It also issues the required messages to the console.
        private void comparePositions(Position firePosition, Position enemyPosition, Ship floatingShip)
        {
            // compare the fire position with the enemy position
            if (firePosition.row == enemyPosition.row && firePosition.column == enemyPosition.column)
            {
                positionIsHit = true;
                enemyPosition.IsFloating = false;
                if (floatingShip.IsShipFloating() == false)
                {
                    // issue hit and sunk message
                    Console.WriteLine(Resources.sinkMessage, floatingShip.ShipType);
                }
                else
                {
                    // issue hit message only
                    Console.WriteLine(Resources.hitMessage);
                }
            }
            // else do nothing!
        }

        public List<Player> GetEnemyPlayers(Player thisPlayer)
        {
            // need to be careful here i.e. by val not by ref!
            // Must copy the player list values over
            // to a new collection then remove the current player.

            Player[] tempPlayerArray = new Player[playerList.Count];
            playerList.CopyTo(tempPlayerArray);
            var enemiesOnlyList = tempPlayerArray.Where(p => p != thisPlayer).ToList();
            return enemiesOnlyList;
        }

        public void CheckForWinner()
        {
            IsGameOver = false;
            if (playerList.Count < 2)
            {
                Console.WriteLine(Resources.winMessage, playerList[0].PlayerName);
                IsGameOver = true;
            }
        }

        public void UpdatePlayerList()
        {
            var tempUpdateList = playerList;
            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].IsPlayerAlive() == false)
                {
                    Console.WriteLine(Resources.leaveMessage, playerList[i].PlayerName);
                    tempUpdateList.Remove(playerList[i]);
                }
            }
            playerList = tempUpdateList;
        }

        private void showMissMessage()
        {
            if (!positionIsHit)
            {
                Console.WriteLine(Resources.missMessage);
            }
            // else do nothing
        }
    }
}
