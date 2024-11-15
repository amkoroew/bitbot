using Player.Models;

namespace Player.Logic;

public abstract class Strategy
{
    public static PlayerAction[] Decide(GameState gameState) =>
        BaseUtils.GetMyBases(gameState).Select(x => new PlayerAction
        {
            Amount = x.Population,
            Source = x.Uid,
            Destination = Map.GetNeighbours(x, gameState.Bases).First().Uid
        }).ToArray();
}