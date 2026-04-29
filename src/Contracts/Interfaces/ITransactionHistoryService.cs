using Contracts.Responses;

namespace Contracts.Interfaces;

public interface ITransactionHistoryService
{
    TransactionHistoryResponse History(string accountName, Guid sessionId);
}