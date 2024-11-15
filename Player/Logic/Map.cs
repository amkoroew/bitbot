using Player.Models;

namespace Player.Logic;

internal static class Map
{
    internal static uint CalculateDistanceBetweenBases(Base source, Base destination) =>
        (uint)Math.Sqrt(
            Math.Pow(Math.Abs(source.Position.X - destination.Position.X), 2) +
            Math.Pow(Math.Abs(source.Position.Y - destination.Position.Y), 2) +
            Math.Pow(Math.Abs(source.Position.Z - destination.Position.Z), 2));

    internal static List<Base> GetNeighbours(Base source, List<Base> bases) =>
        bases.OrderBy(x => CalculateDistanceBetweenBases(source, x)).Skip(1).ToList();

    public static uint GetRemainingBitsAfterTravel(Base source, Base destination, PathConfig pathConfig,
        uint numberBits)
    {
        var remainingDistance = CalculateDistanceBetweenBases(source, destination) - pathConfig.GracePeriod;
        return (uint)(remainingDistance <= 0 ? numberBits : numberBits - (remainingDistance * pathConfig.DeathRate));
    }
}