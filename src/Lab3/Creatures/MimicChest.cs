using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : IFighterOnTable
{
    public Health Health { get; private set; }

    public Attack Attack { get; private set; }

    public bool IsAlive => Health.IsAlive;

    public void TakeDamage(Attack damage)
    {
        Health = Health.TakeDamage(damage);
    }

    public void PerformAttackOn(IFighterInCombat enemy)
    {
        Health = Health > enemy.Health ? Health : enemy.Health;
        Attack = Attack > enemy.Attack ? Attack : enemy.Attack;
        enemy.TakeDamage(Attack);
    }

    public void SetHealth(Health health)
    {
        Health = health;
    }

    public void SetAttack(Attack attack)
    {
        Attack = attack;
    }

    public IFighterOnTable Clone()
    {
        return new MimicChest(Health, Attack);
    }

    public static MimicChestBuilder Builder => new MimicChestBuilder();

    public static MimicChestBuilder DefaultBuilder
        => MimicChestBuilderDefaultDirector.Direct(new MimicChestBuilder());

    private MimicChest(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public class MimicChestBuilder : CreatureOnTableBuilder<MimicChestBuilder, MimicChest>
    {
        public override MimicChest Build()
        {
            return new MimicChest(Health, Attack);
        }
    }

    private class MimicChestBuilderDefaultDirector
    {
        public static MimicChestBuilder Direct(MimicChestBuilder builder)
        {
            return builder
                .WithAttack(new Attack(1))
                .WithHealth(new Health(1));
        }
    }
}