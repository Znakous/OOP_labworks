namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;

public record Coordinate(double Value)
{
    public static Coordinate operator +(Coordinate left, Coordinate right)
        => new Coordinate(left.Value + right.Value);

    public static Coordinate operator -(Coordinate left, Coordinate right)
        => new Coordinate(left.Value - right.Value);

    public static Coordinate operator *(Coordinate coordinate, double coefficient)
        => new Coordinate(coordinate.Value * coefficient);

    public static Speed operator /(Coordinate coordinate, Time time)
        => new Speed(coordinate.Value / time.Value);

    public static bool operator <(Coordinate left, Coordinate right)
        => left.Value < right.Value;

    public static bool operator >(Coordinate left, Coordinate right)
        => left.Value > right.Value;

    public static bool operator <=(Coordinate left, Coordinate right)
        => left.Value <= right.Value;

    public static bool operator >=(Coordinate left, Coordinate right)
        => left.Value >= right.Value;
}