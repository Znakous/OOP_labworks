using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class EvilFighter : BaseCreature, IFighter
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

    public override IFighter Clone()
    {
        return new EvilFighter(Health, Attack);
    }

    public static EvilFighterBuilder Builder => new EvilFighterBuilder();

    public class EvilFighterBuilder
        : CreatureBuilder
    {
        public override IFighter Build()
        {
            return ApplyModifiers(new EvilFighter(Health, Attack));
        }
    }
}