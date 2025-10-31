using Itmo.ObjectOrientedProgramming.Lab3.FighterFactories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CreaturesTests;

public class CharmMasterTests
{
    [Fact]
    public void CharmMaster_Should_NotDecreaseHealth_When_TakingDamageThroughShield()
    {
        // arrange
        IFighter sufferer = new CharmMasterFactory().Create().Build();
        IFighter clearCopy = new CharmMasterFactory().Create().Build();

        // act
        sufferer.TakeDamage(new Attack(100));

        // assert
        Assert.Equal(clearCopy.Health.Value, sufferer.Health.Value);
    }
}