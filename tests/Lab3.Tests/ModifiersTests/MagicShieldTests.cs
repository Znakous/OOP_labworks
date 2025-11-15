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
        IFighterOnTableBuilder underlyingBuilder = Substitute.For<IFighterOnTableBuilder>();
        IFighterOnTable underlying = Substitute.For<IFighterOnTable>();
        underlyingBuilder.Build().Returns(underlying);
        MagicShield.MagicShieldFighterOnTableBuilder magicShieldBuilder = MagicShield.Builder.WithUnderlying(underlyingBuilder);
        IFighterOnTable magicShield = magicShieldBuilder.Build();
        IFighterOnTable enemy = Substitute.For<IFighterOnTable>();

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
        IFighterOnTableBuilder underlyingBuilder = Substitute.For<IFighterOnTableBuilder>();
        IFighterOnTable underlying = Substitute.For<IFighterOnTable>();
        underlyingBuilder.Build().Returns(underlying);
        MagicShield.MagicShieldFighterOnTableBuilder magicShieldBuilder = MagicShield.Builder.WithUnderlying(underlyingBuilder);
        IFighterOnTable magicShield = magicShieldBuilder.Build();
        IFighterOnTable enemy = Substitute.For<IFighterOnTable>();

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
        IFighterOnTableBuilder underlyingBuilder = Substitute.For<IFighterOnTableBuilder>();
        IFighterOnTable underlying = Substitute.For<IFighterOnTable>();
        underlyingBuilder.Build().Returns(underlying);
        IFighterOnTableBuilder currentBuilder = underlyingBuilder;
        for (int i = 0; i < shieldCount; ++i)
        {
            currentBuilder = new MagicShield.MagicShieldUnderlyingSelector()
                .WithUnderlying(currentBuilder);
        }

        IFighterOnTable fighter = currentBuilder.Build();

        // act
        for (int i = 0; i < attackCount; ++i)
            fighter.TakeDamage(new Attack(100));

        // assert
        underlying.Received(attackCount - shieldCount).TakeDamage(Arg.Any<Attack>());
    }
}