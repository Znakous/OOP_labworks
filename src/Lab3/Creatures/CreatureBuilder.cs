using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public abstract class CreatureBuilder<TBuilder, T> : IBuilder where TBuilder : CreatureBuilder<TBuilder, T>
    where T : IEditableFighter
{
    protected Health Health { get; private set; }

    protected Attack Attack { get; private set; }

    protected CreatureBuilder()
    {
        Health = Health.Zero;
        Attack = Attack.Zero;
    }

    public TBuilder WithHealth(int health)
    {
        Health = new Health(health);
        return (TBuilder)this;
    }

    public TBuilder WithAttack(int attack)
    {
        Attack = new Attack(attack);
        return (TBuilder)this;
    }

    public abstract T Build();

    IEditableFighter IBuilder.Build()
    {
        return Build();
    }
}