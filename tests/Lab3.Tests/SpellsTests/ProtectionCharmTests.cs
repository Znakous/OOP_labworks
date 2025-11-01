using Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.SpellsTests;

public class ProtectionCharmTests
{
    [Fact]
    public void ProtectionCharm_Should_ApplyMagicShield_When_BeingAppliedOnFighter()
    {
        // arrange
        var protectionCharm = new ProtectionCharm();
        IFighterOnTable fighter = new InvincibleHorrorBuilderFactory().Create().Build();

        // act
        fighter = protectionCharm.GetAppliedOn(fighter);

        // assert
        Assert.IsType<MagicShield>(fighter);
    }
}