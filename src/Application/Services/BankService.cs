using Abstractions.Repositories;
using Contracts.Interfaces;
using Contracts.Responses;
using Domain.Entities;
using Domain.Models.ValueObjects;

namespace Application.Services;

public class BankService : IBankService
{
    private readonly BankAccountService _bankAccountService;

    private readonly ISessionRepository _sessionRepository;

    public BankService(
        IAccountRepository accountRepository,
        ISessionRepository sessionRepository,
        IExecutedTransactionRepository executedTransactionRepository)
    {
        _bankAccountService = new BankAccountService(
            accountRepository,
            executedTransactionRepository);
        _sessionRepository = sessionRepository;
    }

    public BalanceResponse CheckBalance(string accountName, Guid sessionId)
    {
        var account = new AccountName(accountName);
        Session? session = _sessionRepository.GetById(sessionId);
        if (session is null)
        {
            return new BalanceResponse.BadRequest("Session not found");
        }

        if (session is Session.UserSession userSession && userSession.AccountName != account)
        {
            return new BalanceResponse.Unauthorized("Account doesn't belong to this session");
        }

        return _bankAccountService.CheckBalance(account);
    }

    public DepositResponse Deposit(string accountName, Guid sessionId, decimal amount)
    {
        var account = new AccountName(accountName);
        Session? session = _sessionRepository.GetById(sessionId);
        if (session is null)
        {
            return new DepositResponse.BadRequest("Session not found");
        }

        if (session is Session.UserSession userSession && userSession.AccountName != account)
        {
            return new DepositResponse.Unauthorised("Account doesn't belong to this session");
        }

        return _bankAccountService.Deposit(account, new Money(amount));
    }

    public WithdrawResponse Withdraw(string accountName, Guid sessionId, decimal amount)
    {
        var account = new AccountName(accountName);
        Session? session = _sessionRepository.GetById(sessionId);
        if (session is null)
        {
            return new WithdrawResponse.BadRequest("Session not found");
        }

        if (session is Session.UserSession userSession && userSession.AccountName != account)
        {
            return new WithdrawResponse.Unauthorised("Account doesn't belong to this session");
        }

        return _bankAccountService.Withdraw(account, new Money(amount));
    }
}