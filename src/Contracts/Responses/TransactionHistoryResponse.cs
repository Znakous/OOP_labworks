using Contracts.DTOs;

namespace Contracts.Responses;

public abstract record TransactionHistoryResponse
{
    public sealed record Success(IEnumerable<TransactionDto> Transactions) : TransactionHistoryResponse;

    public sealed record BadRequest(string ErrorMessage) : TransactionHistoryResponse;

    public sealed record Unauthorised(string ErrorMessage) : TransactionHistoryResponse;
}