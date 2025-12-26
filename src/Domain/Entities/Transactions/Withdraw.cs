using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Errors;
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

    public string Name => "Withdraw";

    public TransactionExecutionResult Execute(Account account)
    {
        if (account.Balance < _amount)
        {
            return new TransactionExecutionResult.Failure(
                new InsufficientBalance("withdraw"));
        }

        Money before = account.Balance;
        account.Balance -= _amount;
        var executedVersion = new ExecutedTransaction("Withdraw", DateTime.Now, before, account.Balance);
        return new TransactionExecutionResult.Success(executedVersion);
    }
}