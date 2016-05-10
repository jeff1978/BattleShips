using System.Collections.Generic;
using BattleShips.BattleGround;
using BattleShips.BShip;

namespace BattleShips
{
    public interface IPlayerShipValidation
    {
        bool CanShipBeAdded(Sea gameSea, List<Position> thisShipPositions, List<Position> myShipPositions);
        List<Position> GetPlayerShipsPositions(List<Ship> PlayerShips);
        bool IsPositionAvailable(Position thisPosition, List<Position> myShipPositions);
        void createPlayerShips(List<ShipTypeInGame> typesInThisGame, Player thisPlayer);
    }
}