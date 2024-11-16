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
    
    internal static List<Base> GetOtherBases(GameState gameState) =>
        gameState.Bases.Where(x => x.Player != gameState.Game.Player).ToList();

    internal static List<Base> GetForeignBases(GameState gameState) =>
        gameState.Bases.Where(x => x.Player != gameState.Game.Player).ToList();

    internal static List<Base> GetOwnNeighbours(GameState gameState, Base source) =>
        GetOwnBases(gameState).OrderBy(x => CalculateDistanceBetweenBases(source, x)).Skip(1).ToList();

    internal static List<Base> GetForeignNeighbours(GameState gameState, Base source) =>
        GetForeignBases(gameState).OrderBy(x => CalculateDistanceBetweenBases(source, x)).Skip(1).ToList();

    internal static uint CalculateMoveCost(Base source, Base destination, PathConfig pathConfig) =>
        (uint)Math.Max(0,
            (int)(CalculateDistanceBetweenBases(source, destination) - pathConfig.GracePeriod) * pathConfig.DeathRate);

    internal static uint CalculateAmountAfterMove(Base source, Base destination, PathConfig pathConfig, uint amount) =>
        amount - CalculateMoveCost(source, destination, pathConfig);

    public static List<(Base Destination, uint Cost)> CalculateConquerCosts(GameState gameState, Base source)
    {
        return GetForeignBases(gameState)
            .Select(x => (Destination: x, Cost: CalculateConquerCost(gameState, source, x)))
            .OrderBy(x => x.Cost)
            .ToList();
    }

    private static uint PredictPopulation(GameState gameState, Base @base, uint ticks)
    {
        var config = gameState.Config.BaseLevels[(int)@base.Level];
        return @base.Player == 0 ? @base.Population : Math.Min(config.MaxPopulation + config.SpawnRate, @base.Population + config.SpawnRate * ticks);
    }

    private static uint CalculateConquerCost(GameState gameState, Base source, Base destination)
    {
        return CalculateMoveCost(source, destination, gameState.Config.Paths) + PredictPopulation(gameState, destination, CalculateDistanceBetweenBases(source, destination)) + 1;
    }
    
    internal static uint CalculateNeededBitsToReachDestinationWithRemainingNumber(Base source, Base destination, PathConfig pathConfig, uint amount) =>
        CalculateMoveCost(source, destination, pathConfig) + amount;
}