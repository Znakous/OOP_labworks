namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public record struct Health(int Value)
{
    public static Health Zero => new Health(0);

    public readonly bool IsAlive => this > Zero;

    public static bool operator >(Health left, Health right)
        => left.Value > right.Value;

    public static bool operator <(Health left, Health right)
        => left.Value < right.Value;

    public static Health operator +(Health left, Health right)
        => new(left.Value + right.Value);

    public static Health operator *(Health health, int coefficient)
        => new(health.Value * coefficient);

    public bool CanEndure(Attack attack)
    {
        return Value > attack.Value;
    }

    public Health TakeDamage(Attack damage)
    {
        if (CanEndure(damage))
        {
            return new Health(Value - damage.Value);
        }

        return Zero;
    }
}