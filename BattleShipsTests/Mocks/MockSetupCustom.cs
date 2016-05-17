using System.Collections.Generic;
using BattleShips.ConsoleChecker;
using System;
using BattleShips.Setup;
using BattleShips.BattleGround;
using BattleShips.BShip;

namespace BattleShipsTests
{
    /// <summary>
    /// This class mocks the console inputs for user commands during Custom game mode setup.
    /// It inplements the IGameSetupParser interface
    /// </summary>
    public class MockSetupCustom : IGameSetupParser
    {
        public int SetNumberOfPlayers()
        {
            return 5;
        }

        public int SetNumberOfShips()
        {
            return 4;
        }

        public GameMode SelectGameMode()
        {
            return GameMode.Custom;
        }

        public Sea SetSeaSize()
        {
            return new Sea(10, 10);
        }
    }
}