using Player.Models;

namespace Player.Tests.Logic;

public class PositionMother
{
    public static Position Simple(int x, int y, int z)
    {
        var position = new Position();
        position.X = x;
        position.Y = y;
        position.Z = z;
        return position;
    }
}