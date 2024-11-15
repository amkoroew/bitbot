using Player.Models;

namespace Player.Tests.Logic;

public class BaseMother
{
    public static Base Simple(String name, int x, int y, int z)
    {
        return new Base
        {
            Position = PositionMother.Simple(x, y, z),
            Name = name,
            Population = 1,
        };
    }

    public static Base Simple()
    {
        return Simple("RandomBase", 1, 1, 1);
    }
}