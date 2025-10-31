using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public abstract class CreatureEditableFighterBuilder<TBuilder, T>
    : IEditableFighterBuilder where TBuilder : CreatureEditableFighterBuilder<TBuilder, T>
    where T : IEditableFighter
{
    protected Health Health { get; private set; }

    protected Attack Attack { get; private set; }

    protected CreatureEditableFighterBuilder()
    {
        Health = Health.Zero;
        Attack = Attack.Zero;
    }

    public TBuilder WithHealth(Health health)
    {
        Health = health;
        return (TBuilder)this;
    }

    IEditableFighterBuilder IEditableFighterBuilder.WithHealth(Health health)
    {
        return WithHealth(health);
    }

    public TBuilder WithAttack(Attack attack)
    {
        Attack = attack;
        return (TBuilder)this;
    }

    IEditableFighterBuilder IEditableFighterBuilder.WithAttack(Attack attack)
    {
        return WithAttack(attack);
    }

    public abstract T Build();

    IEditableFighter IEditableFighterBuilder.Build()
    {
        return Build();
    }
}