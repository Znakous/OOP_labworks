using Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.SpellsTests;

public class PowerEssenceTests
{
    [Fact]
    public void PowerEssence_Should_IncreaseAttackBy5_WhenAppliedOnFighterOnTable()
    {
        // arrange
        var powerEssence = new PowerEssence();
        IFighterOnTable fighter = new InvincibleHorrorBuilderFactory().Create()
            .WithAttack(new Attack(10))
            .Build();

        // act
        fighter = powerEssence.GetAppliedOn(fighter);

        // assert
        Assert.Equal(new Attack(15), fighter.Attack);
    }
}