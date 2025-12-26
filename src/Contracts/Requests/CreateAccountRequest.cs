namespace Contracts.Requests;

public record CreateAccountRequest(
    Guid SessionId,
    string AccountName,
    string PinCode,
    decimal InitialBalance)
{ }