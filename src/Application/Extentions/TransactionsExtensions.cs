using Contracts.DTOs;
using Domain.Models;

namespace Application.Extentions;

public static class TransactionsExtensions
{
    public static TransactionDto MapToDto(ExecutedTransaction transaction)
    {
        return new TransactionDto(
            transaction.BalanceBefore.Value,
            transaction.BalanceAfter.Value,
            transaction.ExecutedAt);
    }
}