using Abstractions.Repositories;
using Domain.Models;
using Domain.Models.ValueObjects;

namespace Infrastructure.Repositories;

public class InMemoryExecutedTransactionRepository : IExecutedTransactionRepository
{
    private readonly Dictionary<AccountName, List<ExecutedTransaction>> _transactionDtos = [];

    public void Add(AccountName accountName, ExecutedTransaction transaction)
    {
        if (!_transactionDtos.ContainsKey(accountName))
        {
            _transactionDtos.Add(accountName, new List<ExecutedTransaction>());
        }

        _transactionDtos[accountName].Add(transaction);
    }

    public IEnumerable<ExecutedTransaction>? GetForAccount(AccountName account)
    {
        return _transactionDtos.GetValueOrDefault(account);
    }
}