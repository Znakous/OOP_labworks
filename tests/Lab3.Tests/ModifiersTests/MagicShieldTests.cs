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
        IFighterOnTable underlying = Substitute.For<IFighterOnTable>();
        IFighterOnTable magicShield = new MagicShield.MagicShieldUnderlyingSelector()
            .WithUnderlying(underlying)
            .Build();

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
        IFighterOnTable underlying = Substitute.For<IFighterOnTable>();
        IFighterOnTable magicShield = new MagicShield.MagicShieldUnderlyingSelector()
            .WithUnderlying(underlying)
            .Build();

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
        IFighterOnTable baseFighterOnTable = Substitute.For<IFighterOnTable>();
        IFighterOnTable currentFighterOnTable = baseFighterOnTable;
        for (int i = 0; i < shieldCount; ++i)
        {
            currentFighterOnTable = new MagicShield.MagicShieldUnderlyingSelector()
                .WithUnderlying(currentFighterOnTable)
                .Build();
        }

        // act
        for (int i = 0; i < attackCount; ++i)
            currentFighterOnTable.TakeDamage(new Attack(100));

        // assert
        baseFighterOnTable.Received(attackCount - shieldCount).TakeDamage(Arg.Any<Attack>());
    }
}