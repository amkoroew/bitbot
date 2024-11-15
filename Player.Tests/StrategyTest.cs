using FluentAssertions;
using Newtonsoft.Json;
using Player.Logic;
using Player.Models;

namespace Player.Tests;

public class StrategyTest
{
    [Fact]
    public void Idle()
    {
        var gameState = JsonConvert.DeserializeObject<GameState>(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestGameState.json"))) ?? throw new InvalidOperationException();
        Strategy.Decide(gameState).Should().BeEmpty();
    }
}