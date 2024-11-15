using PlayerDotNet.Models;

namespace PlayerDotNet.Logic;

public class BaseUtils
{
    public static Base getBaseWithHighestPops(Base[] bases)
    {
        return bases[0];
    }
    
    public static Base[] GetMyBases(GameState gameState)
    {
        var myPlayerId = gameState.Game.Player;
        return gameState.Bases.Where(b => b.Player == myPlayerId).ToArray();
    }
    
}