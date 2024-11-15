using PlayerDotNet.Models;

namespace PlayerDotNet.Logic;

public class BaseUtils
{
    public static Base GetBaseWithHighestPops(List<Base> bases)
    {
        return bases.OrderByDescending(i => i.Population).FirstOrDefault();
    }
}