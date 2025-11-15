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
        IFighterOnTableBuilder underlyingBuilder = Substitute.For<IFighterOnTableBuilder>();
        IFighterOnTable underlying = Substitute.For<IFighterOnTable>();
        underlyingBuilder.Build().Returns(underlying);
        AttackMastery.AttackMasteryFighterOnTableBuilder attackMasteryBuilder = AttackMastery.Builder.WithUnderlying(underlyingBuilder);
        IFighterOnTable attackMastery = attackMasteryBuilder.Build();
        IFighterOnTable enemy = Substitute.For<IFighterOnTable>();
        enemy.IsAlive.Returns(true);

        // act
        attackMastery.PerformAttackOn(enemy);

        // assert
        underlying.Received(2).PerformAttackOn(Arg.Any<IFighterOnTable>());
    }

    [Fact]
    public void AttackMastery_Should_CallUnderlyingAttackOnce_When_EnemyDies()
    {
        // arrange
        IFighterOnTableBuilder underlyingBuilder = Substitute.For<IFighterOnTableBuilder>();
        IFighterOnTable underlying = Substitute.For<IFighterOnTable>();
        underlyingBuilder.Build().Returns(underlying);
        AttackMastery.AttackMasteryFighterOnTableBuilder attackMasteryBuilder = AttackMastery.Builder.WithUnderlying(underlyingBuilder);
        IFighterOnTable attackMastery = attackMasteryBuilder.Build();
        IFighterOnTable enemy = Substitute.For<IFighterOnTable>();
        enemy.IsAlive.Returns(false);

        // act
        attackMastery.PerformAttackOn(enemy);

        // assert
        underlying.Received(1).PerformAttackOn(Arg.Any<IFighterOnTable>());
    }
}