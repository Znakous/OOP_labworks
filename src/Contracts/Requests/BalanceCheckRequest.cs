namespace Contracts.Requests;

public record BalanceCheckRequest(Guid SessionId, string AccountName);