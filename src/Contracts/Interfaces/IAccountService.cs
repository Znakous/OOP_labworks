using Contracts.Responses;

namespace Contracts.Interfaces;

public interface IAccountService
{
    CreateAccountResponse CreateAccount(string accountName, string pinCode, decimal initialBalance, Guid sessionId);
}