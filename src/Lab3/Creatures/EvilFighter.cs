using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class EvilFighter : IFighterOnTable
{
    public Health Health { get; private set; }

    public Attack Attack { get; private set; }

    public bool IsAlive => Health.IsAlive;

    public void TakeDamage(Attack damage)
    {
        Health = Health.TakeDamage(damage);
        if (IsAlive)
        {
            Attack *= 2;
        }
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
        return new EvilFighter(Health, Attack);
    }

    public static EvilFighterBuilder Builder => new EvilFighterBuilder();

    public static EvilFighterBuilder DefaultBuilder
        => EvilFighterBuilderDefaultDirector.Direct(new EvilFighterBuilder());

    private EvilFighter(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public class EvilFighterBuilder
        : CreatureOnTableBuilder<EvilFighterBuilder, EvilFighter>
    {
        public override EvilFighter Build()
        {
            return new EvilFighter(Health, Attack);
        }
    }

    private class EvilFighterBuilderDefaultDirector
    {
        public static EvilFighterBuilder Direct(EvilFighterBuilder builder)
        {
            return builder
                .WithAttack(new Attack(1))
                .WithHealth(new Health(6));
        }
    }
}