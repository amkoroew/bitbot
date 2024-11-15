using FluentAssertions;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Player.Logic;
using Player.Models;

namespace Player.Tests.Logic;

[TestSubject(typeof(Map))]
public class MapTest
{

    [Fact]
    public void CalculateMoveCost_ShouldReturn0_WhenBasesAreSame()
    {
        var gameState = JsonConvert.DeserializeObject<GameState>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestGameState.json"))) ?? throw new InvalidOperationException();
        var @base = gameState.Bases.First();
        Map.CalculateMoveCost(@base, @base, gameState.Config.Paths).Should().Be(0);
    }
}