namespace Contracts.Requests;

public record CreateUserSessionRequest(string AccountName, string PinCode);