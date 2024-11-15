using Player.Models;

namespace Player.Logic;

public abstract class Strategy
{
    public static PlayerAction[] Decide(GameState gameState)
    {
        return [new PlayerAction()];
    }
}