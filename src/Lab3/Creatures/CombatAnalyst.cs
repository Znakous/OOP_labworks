using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CombatAnalyst : BaseCreature, IFighterOnTable
{
    private CombatAnalyst(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public override void PerformAttackOn(IFighterOnTable enemy)
    {
        Attack += new Attack(2);
        enemy.TakeDamage(Attack);
    }

    public IFighterOnTable Clone()
    {
        return new CombatAnalyst(Health, Attack);
    }

    public static CombatAnalystBuilder Builder => new CombatAnalystBuilder();

    public class CombatAnalystBuilder
        : CreatureOnTableBuilder
    {
        public override CombatAnalyst Build()
        {
            return new CombatAnalyst(Health, Attack);
        }
    }
}