using Abstractions.Repositories;
using Contracts.Responses;
using Domain.Entities;
using Domain.Models.ValueObjects;

namespace Application.Services;

public class AccountService
{
    private readonly IAccountRepository _accountRepository;

    private readonly ISessionRepository _sessionRepository;

    public AccountService(IAccountRepository accountRepository, ISessionRepository sessionRepository)
    {
        _accountRepository = accountRepository;
        _sessionRepository = sessionRepository;
    }

    public CreateAccountResponse CreateAccount(string accountName, string pinCode, decimal initialBalance, Guid sessionId)
    {
        var accountNameObj = new AccountName(accountName);
        Session? session = _sessionRepository.GetById(sessionId);
        if (session is null)
        {
            return new CreateAccountResponse.BadRequest("Session not found");
        }

        if (session is not Session.AdminSession)
        {
            return new CreateAccountResponse.Unauthorised("Session isn't an admin one");
        }

        if (_accountRepository.GetByName(accountNameObj) is not null)
        {
            return new CreateAccountResponse.BadRequest("Account already exists");
        }

        var account = new Account(accountNameObj, new PinCode(pinCode), new Money(initialBalance));
        _accountRepository.Add(account);
        return new CreateAccountResponse.Success();
    }
}