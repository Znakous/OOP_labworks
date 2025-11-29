using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.ModifiersTests;

public class AttackMasteryTests
{
    [Fact]
    public void AttackMastery_Should_CallUnderlyingAttackTwice_When_EnemyStaysAlive()
    {
        // arrange
        IFighterBuilder underlyingBuilder = Substitute.For<IFighterBuilder>();
        IFighter underlying = Substitute.For<IFighter>();
        underlyingBuilder.Build().Returns(underlying);
        var attackMastery = new AttackMastery(underlyingBuilder.Build());
        IFighter enemy = Substitute.For<IFighter>();
        enemy.IsAlive.Returns(true);

        // act
        attackMastery.PerformAttackOn(enemy);

        // assert
        underlying.Received(2).PerformAttackOn(Arg.Any<IFighter>());
    }

    [Fact]
    public void AttackMastery_Should_CallUnderlyingAttackOnce_When_EnemyDies()
    {
        // arrange
        IFighterBuilder underlyingBuilder = Substitute.For<IFighterBuilder>();
        IFighter underlying = Substitute.For<IFighter>();
        underlyingBuilder.Build().Returns(underlying);
        var attackMastery = new AttackMastery(underlyingBuilder.Build());
        IFighter enemy = Substitute.For<IFighter>();
        enemy.IsAlive.Returns(false);

        // act
        attackMastery.PerformAttackOn(enemy);

        // assert
        underlying.Received(1).PerformAttackOn(Arg.Any<IFighter>());
    }
}