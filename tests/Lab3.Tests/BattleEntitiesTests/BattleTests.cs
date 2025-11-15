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
        var firstTable = new Table(new ModuleCounter());
        firstTable.AddFighter(fighterOnTableForFirstTable);
        var secondTable = new Table(new ModuleCounter());
        var battle = new Battle(firstTable, secondTable);

        // act
        BattleResult result = battle.Proceed();

        // assert
        Assert.IsType<BattleResult.WinFirst>(result);
    }

    [Fact]
    public void Battle_Should_CallADraw_When_FirstTableCanNotProvideFighterAndSecondTableCanNotProvide()
    {
        // arrange
        var firstTable = new Table(new ModuleCounter());
        var secondTable = new Table(new ModuleCounter());
        var battle = new Battle(firstTable, secondTable);

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
        var firstTable = new Table(new ModuleCounter());
        firstTable.AddFighter(fighterOnTableForFirstTable);
        var secondTable = new Table(new ModuleCounter());
        secondTable.AddFighter(fighterOnTableForSecondTable);
        var battle = new Battle(firstTable, secondTable);

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
        var firstTable = new Table(new ModuleCounter());
        firstTable.AddFighter(fighterOnTableForFirstTable);
        var secondTable = new Table(new ModuleCounter());
        secondTable.AddFighter(fighterOnTableForSecondTable);
        var battle = new Battle(firstTable, secondTable);

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
        var firstTable = new Table(new ModuleCounter());
        firstTable.AddFighter(fighterOnTableForFirstTable);
        var secondTable = new Table(new ModuleCounter());
        secondTable.AddFighter(fighterOnTableForSecondTable);
        var battle = new Battle(firstTable, secondTable);

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
        var firstTable = new Table(new ModuleCounter());
        firstTable.AddFighter(fighterOnTableForFirstTable);
        var secondTable = new Table(new ModuleCounter());
        secondTable.AddFighter(fighterOnTableForSecondTable);
        var battle = new Battle(firstTable, secondTable);

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
        var firstTable = new Table(new ModuleCounter());
        firstTable.AddFighter(fighterOnTableForFirstTable);
        var secondTable = new Table(new ModuleCounter());
        secondTable.AddFighter(fighterOnTableForSecondTable);
        var battle = new Battle(firstTable, secondTable);

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
        var firstTable = new Table(new ModuleCounter());
        firstTable.AddFighter(fighterOnTableForFirstTable);
        var secondTable = new Table(new ModuleCounter());
        secondTable.AddFighter(fighterOnTableForSecondTable);
        var battle = new Battle(firstTable, secondTable);

        // act
        BattleResult result = battle.Proceed();

        // assert
        Assert.IsType<BattleResult.WinSecond>(result);
    }

    [Fact]
    public void Battle_Should_ChooseSecondFighterAsWinner_When_FirstTableHasMoreCharmMasters()
    {
        // arrange
        int firstCharmMasterCount = 2;
        int secondCharmMasterCount = 5;
        IFighterOnTableBuilder builderForFirst = new CharmMasterBuilderFactory().Create();
        IFighterOnTableBuilder builderForSecond = new CharmMasterBuilderFactory().Create();
        var firstTable = new Table(new ModuleCounter());
        var secondTable = new Table(new ModuleCounter());
        for (int i = 0; i < firstCharmMasterCount; i++)
        {
            firstTable.AddFighter(builderForFirst.Build());
        }

        for (int i = 0; i < secondCharmMasterCount; i++)
        {
            secondTable.AddFighter(builderForSecond.Build());
        }

        var battle = new Battle(firstTable, secondTable);

        // act
        BattleResult result = battle.Proceed();

        // assert
        Assert.IsType<BattleResult.WinSecond>(result);
    }
}