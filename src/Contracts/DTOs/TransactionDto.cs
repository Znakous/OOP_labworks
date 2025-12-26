namespace Contracts.DTOs;

public record TransactionDto(decimal BalanceBefore, decimal BalanceAfter, DateTime ExecutedAt);