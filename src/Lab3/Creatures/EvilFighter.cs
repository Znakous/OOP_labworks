using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class EvilFighter : BaseCreature, IFighterOnTable
{
    private EvilFighter(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public override void TakeDamage(Attack damage)
    {
        Health = Health.TakeDamage(damage);
        if (IsAlive)
        {
            Attack *= 2;
        }
    }

    public IFighterOnTable Clone()
    {
        return new EvilFighter(Health, Attack);
    }

    public static EvilFighterBuilder Builder => new EvilFighterBuilder();

    public class EvilFighterBuilder
        : CreatureOnTableBuilder
    {
        public override EvilFighter Build()
        {
            return new EvilFighter(Health, Attack);
        }
    }
}