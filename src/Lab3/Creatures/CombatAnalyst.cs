using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CombatAnalyst : BaseCreature, IEditableFighter
{
    public void PerformAttackOn(IFighter enemy)
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

    public IEditableFighter Clone()
    {
        return new CombatAnalyst(Health, Attack);
    }

    private CombatAnalyst(Health health, Attack attack)
        : base(health, attack) { }

    public class CombatAnalystEditableFighterBuilder
        : CreatureEditableFighterBuilder<CombatAnalystEditableFighterBuilder, CombatAnalyst>
    {
        public override CombatAnalyst Build()
        {
            return new CombatAnalyst(Health, Attack);
        }
    }

    public class CombatAnalystBuilderDefaultDirector
    {
        public CombatAnalystEditableFighterBuilder Direct(CombatAnalystEditableFighterBuilder editableFighterBuilder)
        {
            return editableFighterBuilder
                .WithAttack(new Attack(2))
                .WithHealth(new Health(4));
        }
    }
}