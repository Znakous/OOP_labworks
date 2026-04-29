using Contracts.Responses;

namespace Contracts.Interfaces;

public interface IBankService
{
    BalanceResponse CheckBalance(string accountName, Guid sessionId);

    DepositResponse Deposit(string accountName, Guid sessionId, decimal amount);

    WithdrawResponse Withdraw(string accountName, Guid sessionId, decimal amount);
}