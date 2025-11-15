using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.ModifiersTests;

public class MagicShieldTests
{
    [Fact]
    public void MagicShield_Should_StopUnderlyingFromTakingDamage_When_TakingDamageOnce()
    {
        // arrange
        IFighterBuilder underlyingBuilder = Substitute.For<IFighterBuilder>();
        IFighter underlying = Substitute.For<IFighter>();
        underlyingBuilder.Build().Returns(underlying);
        var magicShield = new MagicShield(underlyingBuilder.Build());
        IFighter enemy = Substitute.For<IFighter>();

        // act
        magicShield.TakeDamage(new Attack(100));

        // assert
        underlying.Received(0).TakeDamage(Arg.Any<Attack>());
    }

    [Fact]
    public void MagicShield_Should_StopUnderlyingFromTakingDamageOnce_When_TakingDamageManyTimes()
    {
        // arrange
        int attackCount = 10;
        IFighterBuilder underlyingBuilder = Substitute.For<IFighterBuilder>();
        IFighter underlying = Substitute.For<IFighter>();
        underlyingBuilder.Build().Returns(underlying);
        var magicShield = new MagicShield(underlyingBuilder.Build());
        IFighter enemy = Substitute.For<IFighter>();

        // act
        for (int i = 0; i < attackCount; ++i)
            magicShield.TakeDamage(new Attack(100));

        // assert
        underlying.Received(attackCount - 1).TakeDamage(Arg.Any<Attack>());
    }

    [Fact]
    public void MagicShield_Should_StopUnderlyingFromTakingDamageNTimes_When_AppliedNTimes()
    {
        // arrange
        int shieldCount = 4;
        int attackCount = 10;
        IFighterBuilder underlyingBuilder = Substitute.For<IFighterBuilder>();
        IFighter underlying = Substitute.For<IFighter>();
        underlyingBuilder.Build().Returns(underlying);
        IFighter fighter = underlying;
        for (int i = 0; i < shieldCount; ++i)
        {
            fighter = new MagicShield(fighter);
        }

        // act
        for (int i = 0; i < attackCount; ++i)
            fighter.TakeDamage(new Attack(100));

        // assert
        underlying.Received(attackCount - shieldCount).TakeDamage(Arg.Any<Attack>());
    }
}