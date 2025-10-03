namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;

public record Force(double Value)
{
    public static Force operator +(Force left, Force right)
        => new Force(left.Value + right.Value);

    public static Force operator -(Force left, Force right)
        => new Force(left.Value - right.Value);

    public static Force operator *(Force force, double coefficient)
        => new Force(force.Value * coefficient);

    public static bool operator <(Force left, Force right)
        => left.Value < right.Value;

    public static bool operator >(Force left, Force right)
        => left.Value > right.Value;

    public static bool operator <=(Force left, Force right)
        => left.Value <= right.Value;

    public static bool operator >=(Force left, Force right)
        => left.Value >= right.Value;

    public static Force Create(Acceleration acceleration, Weight weight)
    {
        return new Force(acceleration.Value * weight.Value);
    }
}