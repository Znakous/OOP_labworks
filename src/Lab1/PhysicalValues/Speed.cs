namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;

public record Speed(double Value)
{
    public static Speed operator +(Speed left, Speed right)
        => new Speed(left.Value + right.Value);

    public static Speed operator -(Speed left, Speed right)
        => new Speed(left.Value - right.Value);

    public static Speed operator *(Speed speed, double coefficient)
        => new Speed(speed.Value * coefficient);

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

    public static Speed Create(Acceleration acceleration, Time time)
    {
        return new Speed(acceleration.Value * time.Value);
    }

    public static Speed Create(Coordinate coordinate, Time time)
    {
        if (time.Value == 0)
        {
            throw new ArgumentException("Time cannot be 0 when making speed");
        }

        return new Speed(coordinate.Value / time.Value);
    }
}