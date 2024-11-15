using PlayerDotNet.Models;

namespace PlayerDotNet.Logic
{
    public abstract class Strategy
    {
        public static PlayerAction Decide(GameState? gameState)
        {
            return new PlayerAction();
        }
    }
}
