namespace Contracts.Requests;

public record DepositRequest(Guid SessionId, string AccountName, decimal Amount);