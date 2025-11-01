using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CharmMaster : IFighterOnTable
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
        return new CharmMaster(Health, Attack);
    }

    private CharmMaster(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public static CharmMasterBuilder Builder => new CharmMasterBuilder();

    public static CharmMasterBuilder DefaultBuilder
        => CharmMasterBuilderDefaultDirector.Direct(new CharmMasterBuilder());

    public class CharmMasterBuilder
        : CreatureOnTableBuilder<CharmMasterBuilder, CharmMaster>
    {
        public override CharmMaster Build()
        {
            return new CharmMaster(Health, Attack);
        }
    }

    private class CharmMasterBuilderDefaultDirector
    {
        public static CharmMasterBuilder Direct(CharmMasterBuilder builder)
        {
            return builder
                .WithAttack(new Attack(5))
                .WithHealth(new Health(2));
        }
    }
}