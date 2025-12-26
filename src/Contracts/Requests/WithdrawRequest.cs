namespace Contracts.Requests;

public record WithDrawRequest(Guid SessionId, string AccountName, decimal Amount);