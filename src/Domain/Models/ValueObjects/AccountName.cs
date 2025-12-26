namespace Domain.Models.ValueObjects;

public class AccountName
{
    public string Value { get; }

    public AccountName(string value)
    {
        if (value.Length == 0)
        {
            throw new ArgumentException("Account name cannot be an empty string");
        }

        Value = value;
    }
}