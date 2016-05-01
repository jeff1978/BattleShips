using BattleShips.BattleGround;
using BattleShips.Setup;
using BattleShips.Ship;
using System.Collections.Generic;

namespace BattleShips.ConsoleChecker
{
    public interface IInputParser
    {
        int noOfPlayers { get; set; }
        int noOfShips { get; set; }
        GameMode gameMode { get; set; }
        Sea seaSize { get; set; }
        List<ShipTypeInGame> listOfShipTypes { get; set; }

        void getUserInput(RequestType thisRequest);
    }
}