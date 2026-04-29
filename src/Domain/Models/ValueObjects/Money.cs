namespace Domain.Models.ValueObjects;

public class Money
{
    public decimal Value { get; }

    public Money(decimal value)
    {
        Value = value;
    }

    public static Money operator +(Money left, Money right)
    {
        return new Money(left.Value + right.Value);
    }

    public static Money operator -(Money left, Money right)
    {
        return new Money(left.Value - right.Value);
    }

    public static bool operator <(Money left, Money right)
    {
        return left.Value < right.Value;
    }

    public static bool operator >(Money left, Money right)
    {
        return left.Value > right.Value;
    }
}