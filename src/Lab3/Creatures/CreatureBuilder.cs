using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public abstract class CreatureBuilder : IFighterBuilder
{
    private readonly List<IModifierFactory> _modifierFactories = [];

    protected Health Health { get; private set; }

    protected Attack Attack { get; private set; }

    protected CreatureBuilder()
    {
        Health = Health.Zero;
        Attack = Attack.Zero;
    }

    public IFighterBuilder WithHealth(Health health)
    {
        if (health < Health.Zero)
        {
            throw new ArgumentException("Health of creature on table cannot be less than zero");
        }

        Health = health;
        return this;
    }

    public IFighterBuilder WithAttack(Attack attack)
    {
        Attack = attack;
        return this;
    }

    public IFighterBuilder WithModifierFrom(IModifierFactory modifierFactory)
    {
        _modifierFactories.Add(modifierFactory);
        return this;
    }

    public IFighter ApplyModifiers(IFighter fighter)
    {
        IFighter current = fighter;
        foreach (IModifierFactory factory in _modifierFactories)
        {
            current = factory.Create(current);
        }

        return current;
    }

    public abstract IFighter Build();
}