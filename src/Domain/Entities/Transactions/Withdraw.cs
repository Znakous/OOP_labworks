using Domain.Interfaces;
using Domain.Models;
using Domain.Models.ResultTypes;
using Domain.Models.ValueObjects;

namespace Domain.Entities.Transactions;

public class Withdraw : ITransaction
{
    private readonly Money _amount;

    public Withdraw(Money amount)
    {
        _amount = amount;
    }

    public TransactionExecutionResult Execute(Account account)
    {
        if (account.Balance < _amount)
        {
            return new TransactionExecutionResult.Failure(
                "Can't withdraw more money than current balance");
        }

        Money before = account.Balance;
        account.Balance -= _amount;
        var executedVersion = new ExecutedTransaction("Withdraw", DateTime.Now, before, account.Balance);
        return new TransactionExecutionResult.Success(executedVersion);
    }
}