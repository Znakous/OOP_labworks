namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;

public record Distance(double Value)
{
    public static Distance Zero()
    {
        return new Distance(0);
    }

    public static Distance operator +(Distance left, Distance right)
        => new Distance(left.Value + right.Value);

    public static Distance operator -(Distance left, Distance right)
        => new Distance(left.Value - right.Value);

    public static Distance operator *(Distance distance, double coefficient)
        => new Distance(distance.Value * coefficient);

    public static bool operator <(Distance left, Distance right)
        => left.Value < right.Value;

    public static bool operator >(Distance left, Distance right)
        => left.Value > right.Value;

    public static bool operator <=(Distance left, Distance right)
        => left.Value <= right.Value;

    public static bool operator >=(Distance left, Distance right)
        => left.Value >= right.Value;

    public static Distance Create(Speed speed, Time time)
    {
        return new Distance(time.Value * speed.Value);
    }
}