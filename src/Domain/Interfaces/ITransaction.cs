using Domain.Entities;
using Domain.Models.ResultTypes;

namespace Domain.Interfaces;

public interface ITransaction
{
    TransactionExecutionResult Execute(Account account);
}