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
        IFighter fighterForFirstTable = new MimicChestBuilderFactory().Create().Build();
        var firstTable = new Table(new ContinuousSelector());
        firstTable.AddFighter(fighterForFirstTable);
        var secondTable = new Table(new ContinuousSelector());
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
        var firstTable = new Table(new ContinuousSelector());
        var secondTable = new Table(new ContinuousSelector());
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
        IFighter fighterForFirstTable = new EvilFighterBuilderFactory().Create()
            .WithHealth(new Health(1)).Build();
        IFighter fighterForSecondTable = new EvilFighterBuilderFactory().Create()
            .WithHealth(new Health(1)).Build();
        var firstTable = new Table(new ContinuousSelector());
        firstTable.AddFighter(fighterForFirstTable);
        var secondTable = new Table(new ContinuousSelector());
        secondTable.AddFighter(fighterForSecondTable);
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
        IFighter fighterForFirstTable = new EvilFighterBuilderFactory().Create()
            .WithHealth(new Health(1)).Build();
        IFighter fighterForSecondTable = new EvilFighterBuilderFactory().Create()
            .WithHealth(new Health(100)).Build();
        var firstTable = new Table(new ContinuousSelector());
        firstTable.AddFighter(fighterForFirstTable);
        var secondTable = new Table(new ContinuousSelector());
        secondTable.AddFighter(fighterForSecondTable);
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
        IFighter fighterForFirstTable = new EvilFighterBuilderFactory().Create()
            .WithHealth(new Health(1)).Build();
        IFighter fighterForSecondTable = new EvilFighterBuilderFactory().Create()
            .WithHealth(new Health(100)).Build();
        var firstTable = new Table(new ContinuousSelector());
        firstTable.AddFighter(fighterForFirstTable);
        var secondTable = new Table(new ContinuousSelector());
        secondTable.AddFighter(fighterForSecondTable);
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
        IFighter fighterForFirstTable = new CombatAnalystBuilderFactory().Create()
            .Build();
        IFighter fighterForSecondTable = new EvilFighterBuilderFactory().Create()
            .Build();
        var firstTable = new Table(new ContinuousSelector());
        firstTable.AddFighter(fighterForFirstTable);
        var secondTable = new Table(new ContinuousSelector());
        secondTable.AddFighter(fighterForSecondTable);
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
        IFighter fighterForFirstTable = new EvilFighterBuilderFactory().Create()
            .Build();
        IFighter fighterForSecondTable = new InvincibleHorrorBuilderFactory().Create()
            .Build();
        var firstTable = new Table(new ContinuousSelector());
        firstTable.AddFighter(fighterForFirstTable);
        var secondTable = new Table(new ContinuousSelector());
        secondTable.AddFighter(fighterForSecondTable);
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
        IFighter fighterForFirstTable = new InvincibleHorrorBuilderFactory().Create()
            .Build();
        IFighter fighterForSecondTable = new CharmMasterBuilderFactory().Create()
            .Build();
        var firstTable = new Table(new ContinuousSelector());
        firstTable.AddFighter(fighterForFirstTable);
        var secondTable = new Table(new ContinuousSelector());
        secondTable.AddFighter(fighterForSecondTable);
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
        IFighterBuilder builderForFirst = new CharmMasterBuilderFactory().Create();
        IFighterBuilder builderForSecond = new CharmMasterBuilderFactory().Create();
        var firstTable = new Table(new ContinuousSelector());
        var secondTable = new Table(new ContinuousSelector());
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