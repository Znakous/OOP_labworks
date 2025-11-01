using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class BaseCreature
{
    protected BaseCreature(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public Health Health { get; private set; }

    public Attack Attack { get; private set; }

    public bool IsAlive => Health.IsAlive;

    public void CopyFrom(BaseCreature other)
    {
        Health = other.Health;
        Attack = other.Attack;
    }
}