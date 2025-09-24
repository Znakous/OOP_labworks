namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;

public record Time(double Value)
{
    public static Time operator +(Time left, Time right)
        => new Time(left.Value + right.Value);

    public static Time operator -(Time left, Time right)
        => new Time(left.Value - right.Value);

    public static Time operator *(Time time, double coefficient)
        => new Time(time.Value * coefficient);

    public static bool operator <(Time left, Time right)
        => left.Value < right.Value;

    public static bool operator >(Time left, Time right)
        => left.Value > right.Value;

    public static bool operator <=(Time left, Time right)
        => left.Value <= right.Value;

    public static bool operator >=(Time left, Time right)
        => left.Value >= right.Value;
}