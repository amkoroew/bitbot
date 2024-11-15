using PlayerDotNet.Models;

namespace PlayerDotNet.Logic;

internal static class Map
{
    internal static int CalculateDistanceBetweenBases(Base source, Base destination) =>
        (int) Math.Sqrt(
            Math.Pow(Math.Abs(source.Position.X - destination.Position.X), 2) +
            Math.Pow(Math.Abs(source.Position.Y - destination.Position.Y), 2) +
            Math.Pow(Math.Abs(source.Position.Z - destination.Position.Z), 2));

    internal static List<Base> GetNeighbours(Base source, List<Base> bases) => 
        bases.OrderBy(x => CalculateDistanceBetweenBases(source, x)).Skip(1).ToList();
}