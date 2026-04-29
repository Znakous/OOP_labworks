using Domain.Models;
using Domain.Models.ValueObjects;

namespace Abstractions.Repositories;

public interface IExecutedTransactionRepository
{
    void Add(AccountName accountName, ExecutedTransaction transaction);

    IEnumerable<ExecutedTransaction>? GetForAccount(AccountName account);
}