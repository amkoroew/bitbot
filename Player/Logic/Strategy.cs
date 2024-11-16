using Player.Models;

namespace Player.Logic;

public abstract class Strategy
{
    public static PlayerAction[] Decide(GameState gameState)
    {
        var ownBases = Map.GetOwnBases(gameState);
        if (ownBases.Count > 1)
        {
            return ownBases.Select(x => new PlayerAction
            {
                Amount = BaseUtils.GetSpareBits(gameState, x),
                Source = x.Uid,
                Destination = Map.GetOwnNeighbours(gameState, x).Concat(Map.GetNeighbours(gameState, x)).First().Uid
            }).ToArray();  
        }
        
        return ownBases.Where(x => BaseUtils.GetUpgradeCost(gameState, x) < x.Population).Select(x => new PlayerAction
        {
            Amount = BaseUtils.GetUpgradeCost(gameState, x),
            Source = x.Uid,
            Destination = x.Uid
        }).ToArray();
    }
}