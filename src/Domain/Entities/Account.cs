using Domain.Models.ValueObjects;

namespace Domain.Entities;

public class Account
{
    public AccountName Name { get; private set; }

    public PinCode Pin { get; private set; }

    public Money Balance { get; set; }

    public Account(AccountName name, PinCode pin, Money initialBalance)
    {
        Name = name;
        Pin = pin;
        Balance = initialBalance;
    }

    public bool VerifyPin(PinCode pin) => Pin.Equals(pin);
}