using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class EvilFighter : BaseCreature, IEditableFighter
{
    public void TakeDamage(Attack damage)
    {
        Health.TakeDamage(damage);
        if (IsAlive)
        {
            Attack *= 2;
        }
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
        return new EvilFighter(Health, Attack);
    }

    private EvilFighter(Health health, Attack attack)
        : base(health, attack) { }

    public class EvilFighterBuilder : CreatureBuilder<EvilFighterBuilder, EvilFighter>
    {
        public override EvilFighter Build()
        {
            return new EvilFighter(Health, Attack);
        }
    }

    public class EvilFighterBuilderDefaultDirector
    {
        public EvilFighterBuilder Direct(EvilFighterBuilder builder)
        {
            return builder
                .WithAttack(1)
                .WithHealth(6);
        }
    }
}