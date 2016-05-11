using BattleShips.BattleGround;
using BattleShips.BShip;
using System;
using System.Collections.Generic;

namespace BattleShips
{
    public class GamePlay
    {
        public List<Player> playerList { get; set; }

        public List<Player> GetEnemyPlayers(Player thisPlayer)
        {
            var tempList = playerList;
            tempList.Remove(thisPlayer);
            return tempList;
        }

        public void CheckForWinner()
        {
            if (playerList.Count == 1)
            {
                Console.WriteLine(GamePlayMessages.winMessage, playerList[0].PlayerName);
            }
        }

        public void UpdatePlayerList()
        {
            foreach (var thisPlayer in playerList)
            {
                if (thisPlayer.IsPlayerAlive() == false)
                {
                    Console.WriteLine(GamePlayMessages.leaveMessage, thisPlayer.PlayerName);
                    var tempList = playerList;
                    tempList.Remove(thisPlayer);
                    playerList = tempList;
                }
            }
        }
        ///  **********  U N D E R   D E V E L O P M E N T  ************
        /// 
        ///  while IsGameOver set to false;
        /// for each player in player list
        ///     take turn
        ///         until IsGameOver set to true
        /// 
        /// Use this fire command:
        /// take turn
        ///     for each enemy player
        ///         for each floating ship
        ///             fire command!
        /// 
        /// Fire command(position, floating enemyShip)
        /// set bool hasMissed = true;
        /// for each ship
        ///         for each floating ship position
        ///         if is the same (then - 1. set to Not floating 2.check IsShipFloating : then either Hit or Hit and sunk message)
        /// if hasMissed then issue Miss! message
        /// 
        /// void updatePlayerList(list players){ foreach player: if IsPlayerAlive == false then show message 2. remove player}
        /// void checkForWinner(list of players) if list of players count == 1 then message player name winner}
        /// 
        /// this is a Player Method
        /// bool IsPlayerAlive( ShipList ){ return true if shiplist has at least one floating }
        /// 
        /// this is a shipMethod
        /// bool IsShipFloating() {return true if ship positions.IsFloating > 0}
        ///     
    }
}
