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
            if (this.GetFloatingShips().Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Ship> GetFloatingShips()
        {
            return PlayerShips.Where(p => p.IsShipFloating()).ToList();
        }
    }
}
