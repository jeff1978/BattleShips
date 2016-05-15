using BattleShips.BattleGround;
using BattleShips.BShip;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShips
{
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
            return PlayerShips.Where(p => p.IsShipFloating()==true).ToList();
        }
    }
}
