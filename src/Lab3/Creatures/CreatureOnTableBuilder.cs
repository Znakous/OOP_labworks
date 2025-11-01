using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public abstract class CreatureOnTableBuilder<TBuilder, T>
    : IFighterOnTableBuilder where TBuilder : CreatureOnTableBuilder<TBuilder, T>
    where T : IFighterOnTable
{
    protected Health Health { get; private set; }

    protected Attack Attack { get; private set; }

    protected CreatureOnTableBuilder()
    {
        Health = Health.Zero;
        Attack = Attack.Zero;
    }

    public TBuilder WithHealth(Health health)
    {
        if (health < Health.Zero)
        {
            throw new ArgumentException("Health of creature on table cannot be less than zero");
        }

        Health = health;
        return (TBuilder)this;
    }

    IFighterOnTableBuilder IFighterOnTableBuilder.WithHealth(Health health)
    {
        return WithHealth(health);
    }

    public TBuilder WithAttack(Attack attack)
    {
        Attack = attack;
        return (TBuilder)this;
    }

    IFighterOnTableBuilder IFighterOnTableBuilder.WithAttack(Attack attack)
    {
        return WithAttack(attack);
    }

    public abstract T Build();

    IFighterOnTable IFighterOnTableBuilder.Build()
    {
        return Build();
    }
}