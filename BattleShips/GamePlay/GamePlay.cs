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

        public void PlayGame()
        {
            // show the game start message.
            Console.WriteLine(GamePlayMessages.gameStart);

            bool IsGameOver = false;
            while (IsGameOver == false)
            {
                for (int i = 0; i < playerList.Count; i++)
                {
                    // show fire command message
                    Console.WriteLine(GamePlayMessages.getFireCommand, playerList[i].PlayerName);

                    // get user input for fire command and set it in the property
                    thisGamePlayParser.GetUserInput(RequestType.SetFireCommand);

                    // process the fire command
                    PlayerTakeTurn(thisGamePlayParser.fireCoordinate, playerList[i]);

                    IsGameOver = CheckForWinner();
                }

                Console.WriteLine(GamePlayMessages.gameEndMessage);
                Console.ReadLine();
            }
        }

        private void PlayerTakeTurn(Position firePosition, Player thisPlayer)
        {
            // get a list of players excluding this player:
            var enemies = GetEnemyPlayers(thisPlayer);

            for (int i = 0; i < enemies.Count; i++)
            {
                //get the enemy's floating ships only and fire at each one!
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

                foreach (var enemyPosition in floatingPositions)
                {
                    // compare the fire position with the enemy position
                    if (firePosition.row == enemyPosition.row && firePosition.column == enemyPosition.column)
                    {
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
                        UpdatePlayerList();
                    }
                }
            }
        }

        private List<Player> GetEnemyPlayers(Player thisPlayer)
        {
            var tempList = playerList;
            tempList.Remove(thisPlayer);
            return tempList;
        }

        public bool CheckForWinner()
        {
            if (playerList.Count == 1)
            {
                Console.WriteLine(GamePlayMessages.winMessage, playerList[0].PlayerName);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdatePlayerList()
        {
            for (int i = 0; i < playerList.Count; i++)
                  {
                    if (playerList[i].IsPlayerAlive() == false)
                    {
                        Console.WriteLine(GamePlayMessages.leaveMessage, playerList[i].PlayerName);
                        var tempList = playerList;
                        tempList.Remove(playerList[i]);
                        playerList = tempList;
                    }
                }
        }   
    }
}
