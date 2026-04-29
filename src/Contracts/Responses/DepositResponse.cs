using Contracts.DTOs;

namespace Contracts.Responses;

public abstract record DepositResponse
{
    public sealed record Success(TransactionDto Transaction) : DepositResponse;

    public sealed record BadRequest(string ErrorMessage) : DepositResponse;

    public sealed record Unauthorised(string ErrorMessage) : DepositResponse;
}