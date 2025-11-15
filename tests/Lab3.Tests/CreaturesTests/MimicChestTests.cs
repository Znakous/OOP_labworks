using Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests.CreaturesTests;

public class MimicChestTests
{
    [Fact]
    public void MimicChest_Should_CopyEnemyValues_When_AttackingPowerfulEnemy()
    {
        // arrange
        var highAttackValue = new Attack(100);
        var highHealthValue = new Health(100);
        IFighterOnTable mimicChest = new MimicChestBuilderFactory().Create().Build();
        IFighterOnTable powerfulEnemy = Substitute.For<IFighterOnTable>();
        powerfulEnemy.Attack.Returns(highAttackValue);
        powerfulEnemy.Health.Returns(highHealthValue);

        // act
        mimicChest.PerformAttackOn(powerfulEnemy);

        // assert
        Assert.Equal(highAttackValue, mimicChest.Attack);
        Assert.Equal(highHealthValue, mimicChest.Health);
    }

    [Fact]
    public void MimicChest_Should_SaveValues_When_AttackingWeakerEnemy()
    {
        // arrange
        var highAttackValue = new Attack(100);
        var highHealthValue = new Health(100);
        IFighterOnTable mimicChest = new MimicChestBuilderFactory().Create()
            .WithAttack(highAttackValue).WithHealth(highHealthValue).Build();
        IFighterOnTable weakEnemy = Substitute.For<IFighterOnTable>();
        weakEnemy.Attack.Returns(highAttackValue);
        weakEnemy.Health.Returns(highHealthValue);

        // act
        mimicChest.PerformAttackOn(weakEnemy);

        // assert
        Assert.Equal(highAttackValue, mimicChest.Attack);
        Assert.Equal(highHealthValue, mimicChest.Health);
    }

    [Fact]
    public void MimicChest_Should_ChooseMax_When_AttackingEnemyWithSwappedValues()
    {
        // arrange
        var highAttackValue = new Attack(100);
        var highHealthValue = new Health(100);
        var lowAttackValue = new Attack(1);
        var lowHealthValue = new Health(1);
        IFighterOnTable mimicChest = new MimicChestBuilderFactory().Create()
            .WithAttack(highAttackValue).WithHealth(lowHealthValue).Build();
        IFighterOnTable weakEnemy = Substitute.For<IFighterOnTable>();
        weakEnemy.Attack.Returns(lowAttackValue);
        weakEnemy.Health.Returns(highHealthValue);

        // act
        mimicChest.PerformAttackOn(weakEnemy);

        // assert
        Assert.Equal(highAttackValue, mimicChest.Attack);
        Assert.Equal(highHealthValue, mimicChest.Health);
    }
}