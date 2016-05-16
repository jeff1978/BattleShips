using BattleShips.BattleGround;
using BattleShips.BShip;
using BattleShips.ConsoleChecker;
using System;
using System.Collections.Generic;
using System.Linq;
using BattleShips;

namespace BattleShips
{
    /// <summary>
    /// This class handles all the gameplay once the game and the players have been set up.
    /// </summary>
    public class GamePlay : IGamePlay
    {
        private IGamePlayParser thisGamePlayParser = new GamePlayParser();
        public List<Player> playerList { get; set; }

        // this field will be used to calculate whether to show the Miss!! message
        public bool positionIsHit;

        public void PlayGame()
        {
            // show the game start message.
            Console.WriteLine(GamePlayMessages.gameStart);

            bool IsGameOver = false;
            while (IsGameOver == false)
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    positionIsHit = false;

                    // show fire command message
                    Console.WriteLine(GamePlayMessages.getFireCommand, playerList[i].PlayerName);

                    // get user input for fire command and set it in the property
                    thisGamePlayParser.GetUserInput(RequestType.SetFireCommand);

                    // process the fire command
                    PlayerTakeTurn(thisGamePlayParser.fireCoordinate, playerList[i]);

                    // show the Miss!! message?
                    showMissMessage();

                    // delete any players without floating ships and check for winner
                    UpdatePlayerList();
                    IsGameOver = CheckForWinner();
                }
            }
            Console.WriteLine(GamePlayMessages.gameEndMessage);
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
                    Console.WriteLine(GamePlayMessages.sinkMessage, floatingShip.ShipType);
                }
                else
                {
                    // issue hit message only
                    Console.WriteLine(GamePlayMessages.hitMessage);
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

        public bool CheckForWinner()
        {
            bool winnerFound = false;
            if (playerList.Count < 2)
            {
                Console.WriteLine(GamePlayMessages.winMessage, playerList[0].PlayerName);
                winnerFound = true;
            }
            return winnerFound;
        }

        public void UpdatePlayerList()
        {
            var tempUpdateList = playerList;
            for (int i = 0; i < playerList.Count; i++)
            {
                if (playerList[i].IsPlayerAlive() == false)
                {
                    Console.WriteLine(GamePlayMessages.leaveMessage, playerList[i].PlayerName);
                    tempUpdateList.Remove(playerList[i]);
                }
            }
            playerList = tempUpdateList;
        }

        private void showMissMessage()
        {
            if (!positionIsHit)
            {
                Console.WriteLine(GamePlayMessages.missMessage);
            }
            // else do nothing
        }
    }
}
