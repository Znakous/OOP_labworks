namespace Contracts.Requests;

public record TransactionHistoryRequest(Guid SessionId, string AccountName);