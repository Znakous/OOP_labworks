using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CombatAnalyst : BaseCreature, IFighter
{
    private CombatAnalyst(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public override void PerformAttackOn(IFighter enemy)
    {
        Attack += new Attack(2);
        enemy.TakeDamage(Attack);
    }

    public override IFighter Clone()
    {
        return new CombatAnalyst(Health, Attack);
    }

    public static CombatAnalystBuilder Builder => new CombatAnalystBuilder();

    public class CombatAnalystBuilder
        : CreatureBuilder
    {
        public override IFighter Build()
        {
            return ApplyModifiers(new CombatAnalyst(Health, Attack));
        }
    }
}