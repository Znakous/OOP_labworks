namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;

public record Speed(double Value)
{
    public static Speed operator +(Speed left, Speed right)
        => new Speed(left.Value + right.Value);

    public static Speed operator -(Speed left, Speed right)
        => new Speed(left.Value - right.Value);

    public static Speed operator *(Speed speed, double coefficient)
        => new Speed(speed.Value * coefficient);

    public static Coordinate operator *(Speed speed, Time time)
        => new Coordinate(speed.Value * time.Value);

    public static Acceleration operator /(Speed speed, Time time)
        => new Acceleration(speed.Value * time.Value);

    public static bool operator <(Speed left, Speed right)
        => left.Value < right.Value;

    public static bool operator >(Speed left, Speed right)
        => left.Value > right.Value;

    public static bool operator <=(Speed left, Speed right)
        => left.Value <= right.Value;

    public static bool operator >=(Speed left, Speed right)
        => left.Value >= right.Value;
}