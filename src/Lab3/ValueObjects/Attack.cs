namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public struct Attack
{
    public int Value { get; }

    public Attack(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Attack cannot be less than zero");
        }

        Value = value;
    }

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