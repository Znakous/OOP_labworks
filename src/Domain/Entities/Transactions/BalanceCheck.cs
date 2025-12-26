using Domain.Interfaces;
using Domain.Models;
using Domain.Models.ResultTypes;

namespace Domain.Entities.Transactions;

public class BalanceCheck : ITransaction
{
    public TransactionExecutionResult Execute(Account account)
    {
        var executedVersion = new ExecutedTransaction("Balance", DateTime.Now, account.Balance, account.Balance);
        return new TransactionExecutionResult.Success(executedVersion);
    }
}