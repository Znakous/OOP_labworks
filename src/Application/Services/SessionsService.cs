using Abstractions.Repositories;
using Abstractions.Validators;
using Contracts.Interfaces;
using Contracts.Responses;
using Domain.Entities;
using Domain.Models.ValueObjects;

namespace Application.Services;

public class SessionsService : ISessionService
{
    private readonly IAdminCredentialsValidator _adminCredentialsValidator;

    private readonly ISessionRepository _sessionRepository;

    private readonly IAccountRepository _accountRepository;

    public SessionsService(
        IAdminCredentialsValidator adminCredentialsValidator,
        ISessionRepository sessionRepository,
        IAccountRepository accountRepository)
    {
        _adminCredentialsValidator = adminCredentialsValidator;
        _sessionRepository = sessionRepository;
        _accountRepository = accountRepository;
    }

    public CreateSessionResponse StartAdminSession(string adminPassword)
    {
        if (!_adminCredentialsValidator.ValidatePassword(adminPassword))
            return new CreateSessionResponse.Unauthorized();

        var session = new Session.AdminSession(Guid.NewGuid(), DateTime.Now);
        _sessionRepository.Add(session);
        return new CreateSessionResponse.Success(session.Id);
    }

    public CreateSessionResponse StartUserSession(string name, string pinCode)
    {
        var pin = new PinCode(pinCode);
        var accountName = new AccountName(name);
        Account? account = _accountRepository.GetByName(accountName);
        if (account is null)
        {
            return new CreateSessionResponse.BadRequest("Account not found");
        }

        if (!account.VerifyPin(pin))
        {
            return new CreateSessionResponse.Unauthorized();
        }

        var session = new Session.UserSession(Guid.NewGuid(), accountName, DateTime.Now);
        _sessionRepository.Add(session);
        return new CreateSessionResponse.Success(session.Id);
    }
}