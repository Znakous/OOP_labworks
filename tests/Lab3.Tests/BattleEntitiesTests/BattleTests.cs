using Itmo.ObjectOrientedProgramming.Lab3.BattleEntities;
using Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.BattleEntitiesTests;

public class BattleTests
{
    [Fact]
    public void Battle_Should_ChooseFirstFighterAsWinner_When_FirstTableCanProvideFighterAndSecondTableCanNotProvide()
    {
        // arrange
        IFighterOnTable fighterOnTableForFirstTable = new MimicChestBuilderFactory().Create().Build();
        Table firstTable = new Table.TableBuilder().WithFighter(fighterOnTableForFirstTable).Build();
        Table secondTable = new Table.TableBuilder().Build();
        Battle battle = Battle.Builder.WithFirstTable(firstTable).WithSecondTable(secondTable).Build();

        // act
        BattleResult result = battle.Proceed();

        // assert
        Assert.IsType<BattleResult.WinFirst>(result);
    }

    [Fact]
    public void Battle_Should_CallADraw_When_FirstTableCanNotProvideFighterAndSecondTableCanNotProvide()
    {
        // arrange
        Table firstTable = new Table.TableBuilder().Build();
        Table secondTable = new Table.TableBuilder().Build();
        Battle battle = Battle.Builder.WithFirstTable(firstTable).WithSecondTable(secondTable).Build();

        // act
        BattleResult result = battle.Proceed();

        // assert
        Assert.IsType<BattleResult.Draw>(result);
    }

    [Fact]
    public void Battle_Should_ChooseFirstFighterAsWinner_When_BothTablesProvideTwoIdenticalFighters()
    {
        // arrange
        IFighterOnTable fighterOnTableForFirstTable = new EvilFighterBuilderFactory().Create()
            .WithHealth(new Health(1)).Build();
        IFighterOnTable fighterOnTableForSecondTable = new EvilFighterBuilderFactory().Create()
            .WithHealth(new Health(1)).Build();
        Table firstTable = new Table.TableBuilder().WithFighter(fighterOnTableForFirstTable).Build();
        Table secondTable = new Table.TableBuilder().WithFighter(fighterOnTableForSecondTable).Build();
        Battle battle = Battle.Builder.WithFirstTable(firstTable).WithSecondTable(secondTable).Build();

        // act
        BattleResult result = battle.Proceed();

        // assert
        Assert.IsType<BattleResult.WinFirst>(result);
    }

    [Fact]
    public void Battle_Should_ChooseSecondFighterAsWinner_When_SecondTableHasABetterUnit()
    {
        // arrange
        IFighterOnTable fighterOnTableForFirstTable = new EvilFighterBuilderFactory().Create()
            .WithHealth(new Health(1)).Build();
        IFighterOnTable fighterOnTableForSecondTable = new EvilFighterBuilderFactory().Create()
            .WithHealth(new Health(100)).Build();
        Table firstTable = new Table.TableBuilder()
            .WithFighter(fighterOnTableForFirstTable).Build();
        Table secondTable = new Table.TableBuilder()
            .WithFighter(fighterOnTableForSecondTable).Build();
        Battle battle = Battle.Builder.WithFirstTable(firstTable).WithSecondTable(secondTable).Build();

        // act
        BattleResult result = battle.Proceed();

        // assert
        Assert.IsType<BattleResult.WinSecond>(result);
    }

    [Fact]
    public void Battle_Should_ChooseFirstFighterAsWinner_When_FirstTableHasABetterSquad()
    {
        // arrange
        IFighterOnTable fighterOnTableForFirstTable = new EvilFighterBuilderFactory().Create()
            .WithHealth(new Health(1)).Build();
        IFighterOnTable fighterOnTableForSecondTable = new EvilFighterBuilderFactory().Create()
            .WithHealth(new Health(100)).Build();
        Table firstTable = new Table.TableBuilder()
            .WithFighter(fighterOnTableForFirstTable).Build();
        Table secondTable = new Table.TableBuilder()
            .WithFighter(fighterOnTableForSecondTable).Build();
        Battle battle = Battle.Builder.WithFirstTable(firstTable).WithSecondTable(secondTable).Build();

        // act
        BattleResult result = battle.Proceed();

        // assert
        Assert.IsType<BattleResult.WinSecond>(result);
    }

    [Fact]
    public void Battle_Should_ChooseFirstFighterAsWinner_When_FirstTableHasACombatAnalystAndSecondHasAnEvilFighter()
    {
        // arrange
        IFighterOnTable fighterOnTableForFirstTable = new CombatAnalystBuilderFactory().Create()
            .Build();
        IFighterOnTable fighterOnTableForSecondTable = new EvilFighterBuilderFactory().Create()
            .Build();
        Table firstTable = new Table.TableBuilder()
            .WithFighter(fighterOnTableForFirstTable).Build();
        Table secondTable = new Table.TableBuilder()
            .WithFighter(fighterOnTableForSecondTable).Build();
        Battle battle = Battle.Builder.WithFirstTable(firstTable).WithSecondTable(secondTable).Build();

        // act
        BattleResult result = battle.Proceed();

        // assert
        Assert.IsType<BattleResult.WinFirst>(result);
    }

    [Fact]
    public void Battle_Should_ChooseSecondFighterAsWinner_When_FirstTableHasAnEvilFighterAndSecondHasAnInvincibleHorror()
    {
        // arrange
        IFighterOnTable fighterOnTableForFirstTable = new EvilFighterBuilderFactory().Create()
            .Build();
        IFighterOnTable fighterOnTableForSecondTable = new InvincibleHorrorBuilderFactory().Create()
            .Build();
        Table firstTable = new Table.TableBuilder()
            .WithFighter(fighterOnTableForFirstTable).Build();
        Table secondTable = new Table.TableBuilder()
            .WithFighter(fighterOnTableForSecondTable).Build();
        Battle battle = Battle.Builder.WithFirstTable(firstTable).WithSecondTable(secondTable).Build();

        // act
        BattleResult result = battle.Proceed();

        // assert
        Assert.IsType<BattleResult.WinSecond>(result);
    }

    [Fact]
    public void Battle_Should_ChooseSecondFighterAsWinner_When_FirstTableHasAnInvincibleHorrorAndSecondHasACharmMaster()
    {
        // arrange
        IFighterOnTable fighterOnTableForFirstTable = new InvincibleHorrorBuilderFactory().Create()
            .Build();
        IFighterOnTable fighterOnTableForSecondTable = new CharmMasterBuilderFactory().Create()
            .Build();
        Table firstTable = new Table.TableBuilder()
            .WithFighter(fighterOnTableForFirstTable).Build();
        Table secondTable = new Table.TableBuilder()
            .WithFighter(fighterOnTableForSecondTable).Build();
        Battle battle = Battle.Builder.WithFirstTable(firstTable).WithSecondTable(secondTable).Build();

        // act
        BattleResult result = battle.Proceed();

        // assert
        Assert.IsType<BattleResult.WinSecond>(result);
    }

    [Fact]
    public void Battle_Should_ChooseSecondFighterAsWinner_When_FirstTableHasMoreCharmMasters()
    {
        // arrange
        int firstCharmMasterCount = 4;
        int secondCharmMasterCount = 3;
        IFighterOnTable charmMaster = new CharmMasterBuilderFactory().Create()
            .Build();
        IFighterOnTable fighterOnTableForSecondTable = new CharmMasterBuilderFactory().Create()
            .Build();
        var firstTableBuilder = new Table.TableBuilder();
        var secondTableBuilder = new Table.TableBuilder();
        for (int i = 0; i < firstCharmMasterCount; i++)
        {
            firstTableBuilder = firstTableBuilder.WithFighter(charmMaster);
        }

        for (int i = 0; i < secondCharmMasterCount; i++)
        {
            secondTableBuilder = secondTableBuilder.WithFighter(charmMaster);
        }

        Battle battle = Battle.Builder
            .WithFirstTable(firstTableBuilder.Build())
            .WithSecondTable(secondTableBuilder.Build())
            .Build();

        // act
        BattleResult result = battle.Proceed();

        // assert
        Assert.IsType<BattleResult.WinFirst>(result);
    }
}