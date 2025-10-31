namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public record struct Attack(int Value)
{
    public static Attack Zero => new Attack(0);

    public static bool operator >(Attack left, Attack right)
        => left.Value > right.Value;

    public static bool operator <(Attack left, Attack right)
        => left.Value < right.Value;

    public static Attack operator +(Attack left, Attack right)
        => new(left.Value + right.Value);

    public static Attack operator *(Attack attack, int coefficient)
        => new(attack.Value * coefficient);
}