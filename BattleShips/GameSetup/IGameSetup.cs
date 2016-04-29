﻿using System.Collections.Generic;
using BattleShips.BattleGround;
using BattleShips.Ship;

namespace BattleShips.Setup
{
    public interface IGameSetup
    {
        Sea gameSea { get; }
        List<ShipTypeInGame> listOfShipTypes { get; }
        int numberOfPlayers { get; }

        void setupGame();
        void useMode(GameMode thisMode);
    }
}