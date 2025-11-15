using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class BaseCreature
{
    public Health Health { get; protected set; }

    public Attack Attack { get; protected set; }

    public void SetHealth(Health health)
    {
        Health = health;
    }

    public void SetAttack(Attack attack)
    {
        Attack = attack;
    }

    public bool IsAlive => Health.IsAlive;

    public virtual void TakeDamage(Attack damage)
    {
        Health = Health.TakeDamage(damage);
    }

    public virtual void PerformAttackOn(IFighter enemy)
    {
        enemy.TakeDamage(Attack);
    }
}