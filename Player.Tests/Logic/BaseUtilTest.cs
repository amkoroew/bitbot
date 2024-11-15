using FluentAssertions;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Player.Logic;
using Player.Models;

namespace Player.Tests.Logic;

[TestSubject(typeof(Map))]
public class BaseUtilTest
{
    [Fact]
    public void GetBaseWithHighestPops()
    {
        Base base1 = BaseMother.Simple("Base1", 1, 1, 1);
        base1.Population = 100;
        Base base2 = BaseMother.Simple("Base2", 1, 1, 1);
        base2.Population = 50;

        BaseUtils.GetBaseWithHighestPops([base1, base2]).Should().Be(base1);
    }

    [Fact]
    public void GetBaseWithHighestPopsNull()
    {
        BaseUtils.GetBaseWithHighestPops([]).Should().Be(null);
    }

    [Fact]
    public void GetBaseWithLowestPops()
    {
        Base base1 = BaseMother.Simple("Base1", 1, 1, 1);
        base1.Population = 100;
        Base base2 = BaseMother.Simple("Base2", 1, 1, 1);
        base2.Population = 50;

        BaseUtils.GetBaseWithLowestPops([base1, base2]).Should().Be(base2);
    }

    [Fact]
    public void GetBaseWithLowestPopsNull()
    {
        BaseUtils.GetBaseWithHighestPops([]).Should().Be(null);
    }

    [Fact]
    public void GetBaseWithHighestLevel()
    {
        Base base1 = BaseMother.Simple("Base1", 1, 1, 1);
        base1.Level = 2;
        Base base2 = BaseMother.Simple("Base2", 1, 1, 1);
        base2.Population = 1;

        BaseUtils.GetBaseWithHighestLevel([base1, base2]).Should().Be(base1);
    }

    [Fact]
    public void GetBaseWithLowestLevel()
    {
        Base base1 = BaseMother.Simple("Base1", 1, 1, 1);
        base1.Level = 2;
        Base base2 = BaseMother.Simple("Base2", 1, 1, 1);
        base2.Population = 1;

        BaseUtils.GetBaseWithLowestLevel([base1, base2]).Should().Be(base2);
    }

    [Fact]
    public void GetBaseWithHighestLowestLevel()
    {
        BaseUtils.GetBaseWithHighestLevel([]).Should().Be(null);
        BaseUtils.GetBaseWithLowestLevel([]).Should().Be(null);
    }

    [Fact]
    public void GetBaseWithNameNotInList()
    {
        Base base1 = BaseMother.Simple("Base1", 1, 1, 1);
        Base base2 = BaseMother.Simple("Base2", 1, 1, 1);

        BaseUtils.GetBaseWithName([base1, base2], "ABC").Should().Be(null);
    }

    [Fact]
    public void GetBaseWithName()
    {
        Base base1 = BaseMother.Simple("Base1", 1, 1, 1);
        Base base2 = BaseMother.Simple("Base2", 1, 1, 1);

        BaseUtils.GetBaseWithName([base1, base2], "Base2").Should().Be(base2);
    }
    
    [Fact]
    public void GetTotalPops()
    {
        Base base1 = BaseMother.Simple("Base1", 1, 1, 1);
        base1.Population = 100;
        Base base2 = BaseMother.Simple("Base2", 1, 1, 1);
        base2.Population = 50;

        BaseUtils.GetTotalPops([base1, base2]).Should().Be(150);
    }

    [Fact]
    public void GetMyBases_ShouldReturnBasesForCurrentPlayer()
    {
        var gameState =
            JsonConvert.DeserializeObject<GameState>(
                File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestGameState.json"))) ??
            throw new InvalidOperationException();

        // Act
        var myBases = BaseUtils.GetMyBases(gameState);

        // Assert
        myBases.Should().HaveCount(2);
    }
}