namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public struct ImportanceLevel
{
    private readonly decimal _value;

    public ImportanceLevel(decimal value)
    {
        _value = value;
    }

    public static ImportanceLevel Low()
    {
        return new ImportanceLevel(0);
    }

    public static ImportanceLevel Medium()
    {
        return new ImportanceLevel(10);
    }

    public static ImportanceLevel High()
    {
        return new ImportanceLevel(100);
    }

    public static bool operator <(ImportanceLevel left, ImportanceLevel right)
        => left._value < right._value;

    public static bool operator >(ImportanceLevel left, ImportanceLevel right)
        => left._value > right._value;

    public static bool operator <=(ImportanceLevel left, ImportanceLevel right)
        => left._value <= right._value;

    public static bool operator >=(ImportanceLevel left, ImportanceLevel right)
        => left._value >= right._value;
}