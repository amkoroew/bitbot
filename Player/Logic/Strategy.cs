using Player.Models;

namespace Player.Logic;

public abstract class Strategy
{
    public static PlayerAction[] Decide(GameState gameState)
    {
        var ownBases = Map.GetOwnBases(gameState);
        if (ownBases.Count == 1)
        {
            var own = ownBases.Single();
            var foreignNeighbours = Map.GetForeignNeighbours(gameState, own);
            if (foreignNeighbours.Count != 0)
            {
                return
                [
                    new PlayerAction
                    {
                        Amount = own.Population - 1,
                        Source = own.Uid,
                        Destination = foreignNeighbours.First().Uid
                    }
                ];
            }
            if (BaseUtils.GetUpgradeCost(gameState, own) < own.Population)
            {
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
        }

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