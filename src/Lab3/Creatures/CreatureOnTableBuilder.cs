using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public abstract class CreatureOnTableBuilder : IFighterOnTableBuilder
{
    protected Health Health { get; private set; }

    protected Attack Attack { get; private set; }

    protected CreatureOnTableBuilder()
    {
        Health = Health.Zero;
        Attack = Attack.Zero;
    }

    public IFighterOnTableBuilder WithHealth(Health health)
    {
        if (health < Health.Zero)
        {
            throw new ArgumentException("Health of creature on table cannot be less than zero");
        }

        Health = health;
        return this;
    }

    public IFighterOnTableBuilder WithAttack(Attack attack)
    {
        Attack = attack;
        return this;
    }

    public abstract IFighterOnTable Build();
}