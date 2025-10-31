using Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CreaturesTests;

public class CharmMasterTests
{
    [Fact]
    public void CharmMaster_Should_NotDecreaseHealth_When_TakingDamageThroughShield()
    {
        // arrange
        IFighter sufferer = new CharmMasterBuilderFactory().Create().Build();
        IFighter clearCopy = new CharmMasterBuilderFactory().Create().Build();

        // act
        sufferer.TakeDamage(new Attack(100));

        // assert
        Assert.Equal(clearCopy.Health.Value, sufferer.Health.Value);
    }

    [Fact]
    public void CharmMaster_Should_DecreaseHealth_When_TakingDamageThroughShieldTwice()
    {
        // arrange
        IFighter sufferer = new CharmMasterBuilderFactory().Create().Build();
        IFighter clearCopy = new CharmMasterBuilderFactory().Create().Build();

        // act
        sufferer.TakeDamage(new Attack(100));
        sufferer.TakeDamage(new Attack(1));

        // assert
        Assert.Equal(clearCopy.Health.Value - 1, sufferer.Health.Value);
    }

    [Fact]
    public void CharmMaster_Should_AttackTwice_When_AskedToAttackOnAliveFighter()
    {
        // arrange
        IFighter attacker = new CharmMasterBuilderFactory().Create().Build();
        IFighter enemy = Substitute.For<IFighter>();
        enemy.IsAlive.Returns(true);

        // act
        attacker.PerformAttackOn(enemy);

        // assert
        enemy.Received(2).TakeDamage(Arg.Any<Attack>());
    }
}