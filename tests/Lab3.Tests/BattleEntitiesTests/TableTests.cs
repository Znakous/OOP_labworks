using Itmo.ObjectOrientedProgramming.Lab3.BattleEntities;
using Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.BattleEntitiesTests;

public class TableTests
{
    [Fact]
    public void Table_Should_ReturnFighter_When_FighterGivenAndAskedFor()
    {
        // arrange
        IFighter fighter = new MimicChestBuilderFactory().Create().Build();
        var table = new Table(new ContinuousSelector());
        table.AddFighter(fighter);

        // act
        IFighter? fromTable = table.SendNextAttacker();

        // assert
        Assert.NotNull(fromTable);
    }

    [Fact]
    public void Table_Should_ReturnNull_When_FighterNotGivenAndAskedFor()
    {
        // arrange
        var table = new Table(new ContinuousSelector());

        // act
        IFighter? fromTable = table.SendNextAttacker();

        // assert
        Assert.Null(fromTable);
    }

    [Fact]
    public void Table_Should_ReturnNull_When_AllFightersAreDead()
    {
        // arrange
        IFighter deadFighter1 = new MimicChestBuilderFactory().Create().WithHealth(Health.Zero).Build();
        IFighter deadFighter2 = new CombatAnalystBuilderFactory().Create().WithHealth(Health.Zero).Build();
        var table = new Table(new ContinuousSelector());
        table.AddFighter(deadFighter1);
        table.AddFighter(deadFighter2);

        // act
        IFighter? fromTable = table.SendNextAttacker();

        // assert
        Assert.Null(fromTable);
    }

    [Fact]
    public void Table_Should_ThrowError_When_AddedMoreThan7Fighters()
    {
        // arrange
        var table = new Table(new ContinuousSelector());

        // act
        for (int i = 0; i < 7; i++)
            table.AddFighter(Substitute.For<IFighter>());

        // assert
        Assert.False(table.AddFighter(Substitute.For<IFighter>()));
    }

    [Fact]
    public void Table_Should_ApplySpell_When_AskedForIt()
    {
        // arrange
        IFighter fighter = new MimicChestBuilderFactory().Create().WithAttack(new Attack(5)).Build();
        var table = new Table(new ContinuousSelector());
        table.AddFighter(fighter);

        // act
        table.ApplySpell(new PowerEssence(), fighter);

        // assert
        Assert.Equal(new Attack(10), fighter.Attack);
    }
}