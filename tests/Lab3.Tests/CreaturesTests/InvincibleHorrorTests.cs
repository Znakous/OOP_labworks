using Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CreaturesTests;

public class InvincibleHorrorTests
{
    [Fact]
    public void InvincibleHorror_Should_ResurrectWithHealth1_When_BeingKilled()
    {
        // arrange
        var deadlyAttack = new Attack(1000);
        IFighter invincibleHorror = new InvincibleHorrorBuilderFactory().Create().Build();

        // act
        invincibleHorror.TakeDamage(deadlyAttack);

        // assert
        Assert.Equal(new Health(1), invincibleHorror.Health);
    }
}