using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CombatAnalyst : IFighterOnTable
{
    public Health Health { get; private set; }

    public Attack Attack { get; private set; }

    public bool IsAlive => Health.IsAlive;

    public void PerformAttackOn(IFighterInCombat enemy)
    {
        Attack += new Attack(2);
        enemy.TakeDamage(Attack);
    }

    public void TakeDamage(Attack damage)
    {
        Health = Health.TakeDamage(damage);
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
        return new CombatAnalyst(Health, Attack);
    }

    public static CombatAnalystBuilder Builder => new CombatAnalystBuilder();

    public static CombatAnalystBuilder DefaultBuilder
        => CombatAnalystBuilderDefaultDirector.Direct(new CombatAnalystBuilder());

    private CombatAnalyst(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public class CombatAnalystBuilder
        : CreatureOnTableBuilder<CombatAnalystBuilder, CombatAnalyst>
    {
        public override CombatAnalyst Build()
        {
            return new CombatAnalyst(Health, Attack);
        }
    }

    private class CombatAnalystBuilderDefaultDirector
    {
        public static CombatAnalystBuilder Direct(CombatAnalystBuilder builder)
        {
            return builder
                .WithAttack(new Attack(2))
                .WithHealth(new Health(4));
        }
    }
}