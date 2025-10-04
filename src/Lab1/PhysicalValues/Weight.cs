namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;

public record Weight(double Value)
{
    public static Weight Zero()
    {
        return new Weight(0);
    }

    public static Weight operator +(Weight left, Weight right)
        => new Weight(left.Value + right.Value);

    public static Weight operator -(Weight left, Weight right)
        => new Weight(left.Value - right.Value);

    public static Weight operator *(Weight weight, double coefficient)
        => new Weight(weight.Value * coefficient);

    public static bool operator <(Weight left, Weight right)
        => left.Value < right.Value;

    public static bool operator >(Weight left, Weight right)
        => left.Value > right.Value;

    public static bool operator <=(Weight left, Weight right)
        => left.Value <= right.Value;

    public static bool operator >=(Weight left, Weight right)
        => left.Value >= right.Value;

    public static Weight Create(Force force, Acceleration acceleration)
    {
        if (acceleration.Value == 0)
        {
            throw new ArgumentException("Acceleration cannot be 0");
        }

        return new Weight(force.Value / acceleration.Value);
    }
}