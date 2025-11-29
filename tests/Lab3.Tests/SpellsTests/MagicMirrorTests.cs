using Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.SpellsTests;

public class MagicMirrorTests
{
    [Fact]
    public void MagicMirror_Should_SwapHealthAndAttack_When_AppliedOnFighter()
    {
        // arrange
        var magicMirror = new MagicMirror();
        IFighter fighter = new EvilFighterBuilderFactory().Create()
            .WithAttack(new Attack(10))
            .WithHealth(new Health(1))
            .Build();

        // act
        fighter = magicMirror.GetAppliedOn(fighter);

        // assert
        Assert.Equal(new Health(10), fighter.Health);
        Assert.Equal(new Attack(1), fighter.Attack);
    }
}