using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CharmMaster : BaseCreature, IEditableFighter
{
    public void TakeDamage(Attack damage)
    {
        Health = Health.TakeDamage(damage);
    }

    public void PerformAttackOn(IFighter enemy)
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

    public IEditableFighter Clone()
    {
        return new CharmMaster(Health, Attack);
    }

    private CharmMaster(Health health, Attack attack)
        : base(health, attack) { }

    public class CharmMasterBuilder : CreatureBuilder<CharmMasterBuilder, CharmMaster>
    {
        public override CharmMaster Build()
        {
            return new CharmMaster(Health, Attack);
        }
    }

    public class CharmMasterBuilderDefaultDirector
    {
        public CharmMasterBuilder Direct(CharmMasterBuilder builder)
        {
            return builder
                .WithAttack(5)
                .WithHealth(2);
        }
    }
}