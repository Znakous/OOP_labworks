namespace Contracts.Responses;

public abstract record BalanceResponse
{
    public sealed record Success(decimal Balance) : BalanceResponse;

    public sealed record BadRequest(string ErrorMessage) : BalanceResponse;

    public sealed record Unauthorized(string ErrorMessage) : BalanceResponse;
}