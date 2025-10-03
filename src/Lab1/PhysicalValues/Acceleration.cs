namespace Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;

public record Acceleration(double Value)
{
    public static Acceleration operator +(Acceleration left, Acceleration right)
        => new Acceleration(left.Value + right.Value);

    public static Acceleration operator -(Acceleration left, Acceleration right)
        => new Acceleration(left.Value - right.Value);

    public static Acceleration operator *(Acceleration acceleration, double coefficient)
        => new Acceleration(acceleration.Value * coefficient);

    public static Force operator *(Acceleration acceleration, Weight weight)
        => new Force(acceleration.Value * weight.Value);

    public static Speed operator *(Acceleration acceleration, Time time)
        => new Speed(acceleration.Value * time.Value);

    public static bool operator <(Acceleration left, Acceleration right)
        => left.Value < right.Value;

    public static bool operator >(Acceleration left, Acceleration right)
        => left.Value > right.Value;

    public static bool operator <=(Acceleration left, Acceleration right)
        => left.Value <= right.Value;

    public static bool operator >=(Acceleration left, Acceleration right)
        => left.Value >= right.Value;

    public static Acceleration Create(Speed speedDelta, Time time)
    {
        if (time.Value == 0)
        {
            throw new ArgumentException("Time cannot be zero when making acceleration");
        }

        return new Acceleration(speedDelta.Value / time.Value);
    }

    public static Acceleration Create(Force force, Weight weight)
    {
        if (weight.Value == 0)
        {
            throw new ArgumentException("Weight cannot be zero when making acceleration");
        }

        return new Acceleration(force.Value / weight.Value);
    }
}