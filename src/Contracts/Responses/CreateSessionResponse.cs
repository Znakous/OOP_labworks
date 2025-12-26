namespace Contracts.Responses;

public abstract record CreateSessionResponse
{
    public sealed record Success(Guid SessionGuid) : CreateSessionResponse;

    public sealed record Unauthorized : CreateSessionResponse;

    public sealed record BadRequest(string ErrorMessage) : CreateSessionResponse;
}