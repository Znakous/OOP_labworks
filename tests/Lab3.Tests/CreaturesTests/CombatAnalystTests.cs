using Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CreaturesTests;

public class CombatAnalystTests
{
    [Fact]
    public void CombatAnalyst_Should_IncreaseAttackByTwo_When_AttackingEnemy()
    {
        // arrange
        var initialAttack = new Attack(1);
        IFighterInCombat combatAnalyst = new CombatAnalystBuilderFactory().Create()
            .WithAttack(initialAttack).Build();
        IFighterInCombat enemy = Substitute.For<IFighterInCombat>();

        // act
        combatAnalyst.PerformAttackOn(enemy);

        // assert
        Assert.Equal(initialAttack + new Attack(2), combatAnalyst.Attack);
    }

    [Fact]
    public void CombatAnalyst_Should_KeepIncreasingAttackByTwo_When_AttackingEnemyMultipleTimes()
    {
        // arrange
        int attackCount = 4;
        var initialAttack = new Attack(1);
        IFighterInCombat combatAnalyst = new CombatAnalystBuilderFactory().Create()
            .WithAttack(initialAttack).Build();
        IFighterInCombat enemy = Substitute.For<IFighterInCombat>();

        // act
        for (int i = 0; i < attackCount; ++i)
        {
            combatAnalyst.PerformAttackOn(enemy);
        }

        // assert
        Assert.Equal(initialAttack + (new Attack(2) * attackCount), combatAnalyst.Attack);
    }

    [Fact]
    public void CombatAnalyst_Should_KeepAttackValueIncrement_When_TakingDamage()
    {
        // arrange
        int attackCount = 4;
        var initialAttack = new Attack(1);
        IFighterInCombat combatAnalyst = new CombatAnalystBuilderFactory().Create()
            .WithAttack(initialAttack).WithHealth(new Health(100)).Build();
        IFighterInCombat enemy = Substitute.For<IFighterInCombat>();

        // act
        for (int i = 0; i < attackCount - 1; ++i)
        {
            combatAnalyst.PerformAttackOn(enemy);
        }

        combatAnalyst.TakeDamage(new Attack(1));

        combatAnalyst.PerformAttackOn(enemy);

        // assert
        Assert.Equal(initialAttack + (new Attack(2) * attackCount), combatAnalyst.Attack);
    }
}