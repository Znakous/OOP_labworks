using Abstractions.Repositories;
using Application.Extentions;
using Contracts.Interfaces;
using Contracts.Responses;
using Domain.Entities;
using Domain.Models;
using Domain.Models.ValueObjects;

namespace Application.Services;

public class TransactionHistoryService : ITransactionHistoryService
{
    private readonly IExecutedTransactionRepository _executedTransactionRepository;

    private readonly ISessionRepository _sessionRepository;

    public TransactionHistoryService(IExecutedTransactionRepository executedTransactionRepository, ISessionRepository sessionRepository)
    {
        _executedTransactionRepository = executedTransactionRepository;
        _sessionRepository = sessionRepository;
    }

    public TransactionHistoryResponse History(string accountName, Guid sessionId)
    {
        var account = new AccountName(accountName);
        Session? session = _sessionRepository.GetById(sessionId);
        if (session is null)
        {
            return new TransactionHistoryResponse.BadRequest("Session not found");
        }

        if (session is Session.UserSession userSession && userSession.AccountName != account)
        {
            return new TransactionHistoryResponse.Unauthorised("Account doesn't belong to this session");
        }

        IEnumerable<ExecutedTransaction>? response = _executedTransactionRepository.GetForAccount(account);
        if (response is null)
        {
            return new TransactionHistoryResponse.BadRequest("Account not found");
        }

        return new TransactionHistoryResponse.Success(
            response.Select(x => TransactionsExtensions.MapToDto(x)));
    }
}