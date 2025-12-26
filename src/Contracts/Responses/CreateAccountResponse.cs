namespace Contracts.Responses;

public abstract record CreateAccountResponse
{
    public sealed record Success() : CreateAccountResponse;

    public sealed record BadRequest(string ErrorMessage) : CreateAccountResponse;

    public sealed record Unauthorised(string ErrorMessage) : CreateAccountResponse;
}