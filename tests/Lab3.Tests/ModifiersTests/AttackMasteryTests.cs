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
        IFighterOnTable underlying = Substitute.For<IFighterOnTable>();
        IFighterOnTable attackMastery = new AttackMastery.AttackMasteryUnderlyingSelector()
            .WithUnderlying(underlying)
            .Build();
        IFighterInCombat enemy = Substitute.For<IFighterInCombat>();
        enemy.IsAlive.Returns(true);

        // act
        attackMastery.PerformAttackOn(enemy);

        // assert
        underlying.Received(2).PerformAttackOn(Arg.Any<IFighterInCombat>());
    }

    [Fact]
    public void AttackMastery_Should_CallUnderlyingAttackOnce_When_EnemyDies()
    {
        // arrange
        IFighterOnTable underlying = Substitute.For<IFighterOnTable>();
        IFighterOnTable attackMastery = new AttackMastery.AttackMasteryUnderlyingSelector()
            .WithUnderlying(underlying)
            .Build();
        IFighterInCombat enemy = Substitute.For<IFighterInCombat>();
        enemy.IsAlive.Returns(false);

        // act
        attackMastery.PerformAttackOn(enemy);

        // assert
        underlying.Received(1).PerformAttackOn(Arg.Any<IFighterInCombat>());
    }
}