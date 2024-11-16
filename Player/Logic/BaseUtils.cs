using Player.Models;

namespace Player.Logic;

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
        return bases.Where(i => i.Name == name).FirstOrDefault();
    }

    public static int GetBaseSpawnRate(Base source, GameState gameState)
    {
        return (int)gameState.Config.BaseLevels[(int)source.Level].SpawnRate;
    }

    public static int GetTotalPops(List<Base> bases)
    {
        return (int)bases.Sum(b => b.Population);
    }

    public static Base[] GetMyBases(GameState gameState)
    {
        var myPlayerId = gameState.Game.Player;
        return gameState.Bases.Where(b => b.Player == myPlayerId).ToArray();
    }

    public static uint GetSpareBits(GameState gameState, Base source)
    {
        var config = gameState.Config.BaseLevels[(int)source.Level];
        if (source.Population + config.SpawnRate < config.MaxPopulation) return 0;
        return source.Population - config.MaxPopulation + config.SpawnRate;
    }

    public static uint GetUpgradeCost(GameState gameState, Base source) =>
        gameState.Config.BaseLevels[(int)source.Level].UpgradeCost;
}