using Itmo.ObjectOrientedProgramming.Lab3.BattleEntities;
using Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;
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
        IFighterOnTable fighterOnTable = new MimicChestBuilderFactory().Create().Build();
        Table table = new Table.TableBuilder().WithFighter(fighterOnTable).Build();

        // act
        SendNextFighterResult fromTable = table.SendNextFighter();

        // assert
        Assert.IsType<SendNextFighterResult.Success>(fromTable);
    }

    [Fact]
    public void Table_Should_ReturnNull_When_FighterNotGivenAndAskedFor()
    {
        // arrange
        Table table = new Table.TableBuilder().Build();

        // act
        SendNextFighterResult fromTable = table.SendNextFighter();

        // assert
        Assert.IsType<SendNextFighterResult.Failure>(fromTable);
    }

    [Fact]
    public void Table_Should_ReturnNull_When_AllFightersAreDead()
    {
        // arrange
        IFighterOnTable deadFighter1 = new MimicChestBuilderFactory().Create().WithHealth(Health.Zero).Build();
        IFighterOnTable deadFighter2 = new CombatAnalystBuilderFactory().Create().WithHealth(Health.Zero).Build();
        Table table = new Table.TableBuilder().WithFighter(deadFighter1).WithFighter(deadFighter2).Build();

        // act
        SendNextFighterResult fromTable = table.SendNextFighter();

        // assert
        Assert.IsType<SendNextFighterResult.Failure>(fromTable);
    }

    [Fact]
    public void TableBuilder_Should_ThrowError_When_AddedMoreThan7Fighters()
    {
        // arrange
        var tableBuilder = new Table.TableBuilder();

        // act
        for (int i = 0; i < 7; i++)
            tableBuilder = tableBuilder.WithFighter(Substitute.For<IFighterOnTable>());

        // assert
        Assert.Throws<ArgumentException>(() => tableBuilder.WithFighter(Substitute.For<IFighterOnTable>()));
    }
}