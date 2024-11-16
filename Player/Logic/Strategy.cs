using Player.Models;

namespace Player.Logic;

internal static class Strategy
{
    private static ILogger Logger { get; } =
        LoggerFactory.Create(config => { config.AddSimpleConsole(options =>
        {
            options.IncludeScopes = true;
            options.SingleLine = true;
        }); }).CreateLogger("BitBot");

    public static PlayerAction[] Decide(GameState gameState)
    {
        using var tickScope = Logger.BeginScope($"[{gameState.Game.Tick}]");
        var ownBases = Map.GetOwnBases(gameState);
        if (ownBases.Count == 1)
        {
            using var singleBaseScope= Logger.BeginScope("[single base]");
            Logger.LogInformation("start");
            var own = ownBases.Single();
            var cheapest = Map.CalculateConquerCosts(gameState, own).First();
            if (cheapest.Cost < own.Population)
            {
                Logger.LogInformation("attack");
                return
                [
                    new PlayerAction
                    {
                        Amount = cheapest.Cost,
                        Source = own.Uid,
                        Destination = cheapest.Destination.Uid
                    }
                ];
            }
            if (BaseUtils.GetUpgradeCost(gameState, own) < own.Population)
            {
                Logger.LogInformation("upgrade");
                return
                [
                    new PlayerAction
                    {
                        Amount = BaseUtils.GetUpgradeCost(gameState, own),
                        Source = own.Uid,
                        Destination = own.Uid
                    }
                ];
            }

            Logger.LogInformation("wait");
            return [];
        }

        using var multipleBasesScope = Logger.BeginScope("[multiple bases]");
        Logger.LogInformation("start");
        
        return ownBases.Select(x =>
        {
            var spareBits = BaseUtils.GetSpareBits(gameState, x);
            
            if (spareBits > BaseUtils.GetUpgradeCost(gameState, x))
            {
                return new PlayerAction
                {
                    Amount = BaseUtils.GetUpgradeCost(gameState, x),
                    Source = x.Uid,
                    Destination = x.Uid
                };
            }

            var minimalConquerCost = Map.CalculateConquerCosts(gameState, x).First().Cost;
            if (minimalConquerCost < spareBits)
            {
                return new PlayerAction
                {
                    Amount = minimalConquerCost,
                    Source = x.Uid,
                    Destination = x.Uid
                };
            }
            
            return new PlayerAction
            {
                Amount = spareBits,
                Source = x.Uid,
                Destination = Map.GetOwnNeighbours(gameState, x).First().Uid
            };
        }).ToArray();
    }
}