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

    public static Base GetBaseWithHighestLevel(List<Base> bases)
    {
        return bases.OrderByDescending(i => i.Level).FirstOrDefault();
    }

    public static Base GetBaseWithLowestLevel(List<Base> bases)
    {
        return bases.OrderByDescending(i => i.Level).LastOrDefault();
    }

    public static Base GetBaseWithName(List<Base> bases, String name)
    {
        return bases.Find(i => name.Equals(name));
    }

    public static Base[] GetMyBases(GameState gameState)
    {
        var myPlayerId = gameState.Game.Player;
        return gameState.Bases.Where(b => b.Player == myPlayerId).ToArray();
    }
}