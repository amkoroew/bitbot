using PlayerDotNet.Models;

namespace PlayerDotNet.Logic;

public class BaseUtils
{
    public static Base GetBaseWithHighestPops(List<Base> bases)
    {
        return bases.OrderByDescending(i => i.Population).FirstOrDefault();
    }

    public static Base GetBaseWithLowestPops(List<Base> bases)
    {
        return bases.OrderByDescending(i => i.Population).LastOrDefault();
    }

    public static Base[] GetMyBases(GameState gameState)
    {
        var myPlayerId = gameState.Game.Player;
        return gameState.Bases.Where(b => b.Player == myPlayerId).ToArray();
    }
}