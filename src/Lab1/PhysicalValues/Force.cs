namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;

public record Force(double Value)
{
    public static Force operator +(Force left, Force right)
        => new Force(left.Value + right.Value);

    public static Force operator -(Force left, Force right)
        => new Force(left.Value - right.Value);

    public static Force operator *(Force force, double coefficient)
        => new Force(force.Value * coefficient);

    public static Acceleration operator /(Force force, Weight weight)
        => new Acceleration(force.Value / weight.Value);

    public static Weight operator /(Force force, Acceleration acceleration)
        => new Weight(force.Value / acceleration.Value);

    public static bool operator <(Force left, Force right)
        => left.Value < right.Value;

    public static bool operator >(Force left, Force right)
        => left.Value > right.Value;

    public static bool operator <=(Force left, Force right)
        => left.Value <= right.Value;

    public static bool operator >=(Force left, Force right)
        => left.Value >= right.Value;
}