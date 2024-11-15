using Newtonsoft.Json;
using Player.Models;

namespace Player.Logic;

public abstract class Strategy
{
    public static PlayerAction[] Decide(GameState gameState)
    {
        var actions = BaseUtils.GetMyBases(gameState).Select(x => new PlayerAction
        {
            Amount = x.Population,
            Source = x.Uid,
            Destination = Map.GetOwnNeighbours(gameState, x).Concat(Map.GetNeighbours(gameState, x)).First().Uid
        }).ToArray();
        
        Console.Write(JsonConvert.SerializeObject(actions));
        
        return actions;
    }
}