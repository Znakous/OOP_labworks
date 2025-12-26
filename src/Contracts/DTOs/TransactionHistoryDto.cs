namespace Contracts.DTOs;

public record TransactionHistoryDto(IEnumerable<TransactionDto> Transactions);