using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class BaseCreature
{
    protected BaseCreature(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public Health Health { get; protected set; }

    public Attack Attack { get; protected set; }

    public bool IsAlive => Health.IsAlive;

    public void CopyFrom(BaseCreature other)
    {
        Health = other.Health;
        Attack = other.Attack;
    }
}