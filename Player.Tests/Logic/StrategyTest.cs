using FluentAssertions;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Player.Logic;
using Player.Models;

namespace Player.Tests.Logic;

[TestSubject(typeof(Strategy))]
public class StrategyTest
{
    [Fact]
    public void SmokeTest()
    {
        var gameState = JsonConvert.DeserializeObject<GameState>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestGameState.json"))) ?? throw new InvalidOperationException();
        Strategy.Decide(gameState).Should().NotBeEmpty();
    }
}