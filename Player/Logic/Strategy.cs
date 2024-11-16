using Player.Models;

namespace Player.Logic;

public abstract class Strategy
{
    public static PlayerAction[] Decide(GameState gameState) =>
        BaseUtils.GetMyBases(gameState).Select(x => new PlayerAction
        {
            Amount = BaseUtils.GetSpareBits(gameState, x),
            Source = x.Uid,
            Destination = Map.GetOwnNeighbours(gameState, x).Concat(Map.GetNeighbours(gameState, x)).First().Uid
        }).ToArray();
}