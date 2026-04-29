using Contracts.DTOs;

namespace Contracts.Responses;

public abstract record WithdrawResponse
{
    public sealed record Success(TransactionDto Transaction) : WithdrawResponse();

    public sealed record BadRequest(string ErrorMessage) : WithdrawResponse();

    public sealed record Unauthorised(string ErrorMessage) : WithdrawResponse();
}