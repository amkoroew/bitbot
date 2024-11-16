using Player.Models;

namespace Player.Logic;

public class Attack
{
    public class PossibleTargets
    {
        public Base source { get; set; }
        public List<Target> targets { get; set; }
    }

    public class Target
    {
        public Base destination { get; set; }
        public int distance { get; set; }
        public int investment { get; set; }
    }


    public static List<PossibleTargets> GetPossibleTargets(GameState gameState, PathConfig pathConfig)
    {
        List<PossibleTargets> possibleTargets = new List<PossibleTargets>();
        foreach (Base ourBase in Map.GetOwnBases(gameState))
        {
            possibleTargets.Add(new PossibleTargets
            {
                source = ourBase,
                targets = GetTargetsInRange(ourBase, Map.GetOtherBases(gameState), pathConfig, gameState)
            });
        }

        return possibleTargets;
    }

    public static List<Target> GetTargetsInRange(Base source, List<Base> destinations, PathConfig pathConfig,
        GameState gameState)
    {
        List<Target> basesInRange = new List<Target>();
        foreach (Base destination in destinations)
        {
            var distance = Map.CalculateDistanceBetweenBases(source, destination);
            var neededBits = Map.CalculateMoveCost(source, destination, pathConfig) + destination.Population +
                             (BaseUtils.GetBaseSpawnRate(destination, gameState) * distance) + 1;
            if (neededBits < source.Population)
                basesInRange.Add(new Target
                {
                    destination = destination,
                    distance = (int)distance,
                    investment = (int)neededBits,
                });
        }

        return basesInRange;
    }
}