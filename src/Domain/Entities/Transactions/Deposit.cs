using Domain.Interfaces;
using Domain.Models;
using Domain.Models.ResultTypes;
using Domain.Models.ValueObjects;

namespace Domain.Entities.Transactions;

public class Deposit : ITransaction
{
    private readonly Money _amount;

    public Deposit(Money amount)
    {
        _amount = amount;
    }

    public TransactionExecutionResult Execute(Account account)
    {
        Money before = account.Balance;
        account.Balance += _amount;
        var executedVersion = new ExecutedTransaction("Deposit", DateTime.Now, before, account.Balance);
        return new TransactionExecutionResult.Success(executedVersion);
    }
}