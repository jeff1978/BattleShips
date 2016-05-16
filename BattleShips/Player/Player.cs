using BattleShips.BattleGround;
using BattleShips.BShip;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
    /// <summary>
    /// This class represents a player who has a name and a list of ships.
    /// </summary>
    public class Player
    {
        public List<Ship> PlayerShips { get; set; }
        public string PlayerName { get; set; }

        public bool IsPlayerAlive()
        {
            bool playerIsAlive = false;
            if (GetFloatingShips().Count() > 0)
            {
                playerIsAlive = true;
            }
            return playerIsAlive;
        }

        public List<Ship> GetFloatingShips()
        {
            return PlayerShips.Where(p => p.IsShipFloating()).ToList();
        }
    }
}
