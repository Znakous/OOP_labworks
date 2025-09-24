namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;

public record Weight(double Value)
{
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
}