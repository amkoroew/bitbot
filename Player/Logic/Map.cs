using Player.Models;

namespace Player.Logic;

internal static class Map
{
    internal static uint CalculateDistanceBetweenBases(Base source, Base destination) =>
        (uint)Math.Sqrt(
            Math.Pow(Math.Abs(source.Position.X - destination.Position.X), 2) +
            Math.Pow(Math.Abs(source.Position.Y - destination.Position.Y), 2) +
            Math.Pow(Math.Abs(source.Position.Z - destination.Position.Z), 2));

    internal static List<Base> GetOwnBases(GameState gameState) =>
        gameState.Bases.Where(x => x.Player == gameState.Game.Player).ToList();

    internal static List<Base> GetAbandonedBases(GameState gameState) =>
        gameState.Bases.Where(x => x.Player == 0).ToList();

    internal static List<Base> GetEnemyBases(GameState gameState) =>
        gameState.Bases.Where(x => x.Player != 0 && x.Player != gameState.Game.Player).ToList();

    internal static List<Base> GetNeighbours(GameState gameState, Base source) =>
        gameState.Bases.OrderBy(x => CalculateDistanceBetweenBases(source, x)).Skip(1).ToList();

    internal static List<Base> GetOwnNeighbours(GameState gameState, Base source) =>
        GetOwnBases(gameState).OrderBy(x => CalculateDistanceBetweenBases(source, x)).Skip(1).ToList();

    internal static uint CalculateMoveCost(Base source, Base destination, PathConfig pathConfig) =>
        (uint)Math.Max(0,
            (int)(CalculateDistanceBetweenBases(source, destination) - pathConfig.GracePeriod) * pathConfig.DeathRate);

    internal static uint CalculateAmountAfterMove(Base source, Base destination, PathConfig pathConfig, uint amount) =>
        amount - CalculateMoveCost(source, destination, pathConfig);
}