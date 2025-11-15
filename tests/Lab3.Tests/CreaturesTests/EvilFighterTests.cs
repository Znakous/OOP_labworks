using Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CreaturesTests;

public class EvilFighterTests
{
    [Fact]
    public void EvilFighter_Should_MultiplyAttack_When_TakingNonDeadlyDamage()
    {
        // arrange
        var highAttackValue = new Attack(100);
        var highHealthValue = new Health(100);
        var lowAttackValue = new Attack(1);
        var lowHealthValue = new Health(1);
        var initialAttackValue = new Attack(1);
        IFighterOnTable evilFighter = new EvilFighterBuilderFactory().Create()
            .WithAttack(initialAttackValue).Build();

        // act
        evilFighter.TakeDamage(lowAttackValue);

        // assert
        Assert.Equal(initialAttackValue * 2, evilFighter.Attack);
    }
}