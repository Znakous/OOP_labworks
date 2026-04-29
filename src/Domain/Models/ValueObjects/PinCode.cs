namespace Domain.Models.ValueObjects;

public class PinCode
{
    public string Value { get; private set; }

    public PinCode(string value)
    {
        if (value.Length < 4)
        {
            throw new ArgumentException("pin code must contain at least 4 characters");
        }

        Value = value;
    }

    public bool Equals(PinCode other)
    {
        return Value == other.Value;
    }
}