using Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.SpellsTests;

public class ResistanceEssenceTests
{
    [Fact]
    public void ResistanceEssence_Should_IncreaseHealthBy5_WhenAppliedOnFighter()
    {
        // arrange
        var resistanceEssence = new ResistanceEssence();
        IFighter fighter = new InvincibleHorrorBuilderFactory().Create()
            .WithHealth(new Health(10))
            .Build();

        // act
        fighter = resistanceEssence.GetAppliedOn(fighter);

        // assert
        Assert.Equal(new Health(15), fighter.Health);
    }
}