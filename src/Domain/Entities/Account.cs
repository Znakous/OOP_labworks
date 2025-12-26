using Domain.Interfaces;
using Domain.Models.ResultTypes;
using Domain.Models.ValueObjects;

namespace Domain.Entities;

public class Account
{
    public AccountName Name { get; private set; }

    public PinCode Pin { get; private set; }

    public Money Balance { get; set; }

    public DateTime CreatedAt { get; private set; }

    private readonly List<ITransaction> _transactions = [];

    public Account(AccountName name, PinCode pin, Money initialBalance)
    {
        Name = name;
        Pin = pin;
        Balance = initialBalance;
    }

    public TransactionExecutionResult PerformTransaction(ITransaction transaction)
    {
        _transactions.Add(transaction);
        return transaction.Execute(this);
    }

    public bool VerifyPin(PinCode pin) => Pin.Equals(pin);
}