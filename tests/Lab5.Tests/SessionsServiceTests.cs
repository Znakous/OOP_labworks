using Abstractions.Repositories;
using Abstractions.Validators;
using Application.Services;
using Contracts.Responses;
using Domain.Entities;
using Domain.Models.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class SessionsServiceTests
{
    [Fact]
    public void StartAdminSession_Should_ReturnUnauthorized_When_InvalidPassword()
    {
        // arrange
        IAdminCredentialsValidator adminValidator = Substitute.For<IAdminCredentialsValidator>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var sessionsService = new SessionsService(adminValidator, sessionRepository, accountRepository);

        adminValidator.ValidatePassword("wrong").Returns(false);

        // act
        CreateSessionResponse result = sessionsService.StartAdminSession("wrong");

        // assert
        Assert.IsType<CreateSessionResponse.Unauthorized>(result);
        sessionRepository.DidNotReceive().Add(Arg.Any<Session>());
    }

    [Fact]
    public void StartAdminSession_Should_ReturnSuccess_When_ValidPassword()
    {
        // arrange
        IAdminCredentialsValidator adminValidator = Substitute.For<IAdminCredentialsValidator>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var sessionsService = new SessionsService(adminValidator, sessionRepository, accountRepository);

        adminValidator.ValidatePassword("correct").Returns(true);

        // act
        CreateSessionResponse result = sessionsService.StartAdminSession("correct");

        // assert
        Assert.IsType<CreateSessionResponse.Success>(result);
        var success = (CreateSessionResponse.Success)result;
        Assert.NotEqual(Guid.Empty, success.SessionGuid);
        sessionRepository.Received(1).Add(Arg.Is<Session.AdminSession>(s => s.Id == success.SessionGuid));
    }

    [Fact]
    public void StartUserSession_Should_ReturnBadRequest_When_AccountNotFound()
    {
        // arrange
        IAdminCredentialsValidator adminValidator = Substitute.For<IAdminCredentialsValidator>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var sessionsService = new SessionsService(adminValidator, sessionRepository, accountRepository);

        accountRepository.GetByName(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns((Account?)null);

        // act
        CreateSessionResponse result = sessionsService.StartUserSession("TestAccount", "1234");

        // assert
        Assert.IsType<CreateSessionResponse.BadRequest>(result);
        var badRequest = (CreateSessionResponse.BadRequest)result;
        Assert.Equal("Account not found", badRequest.ErrorMessage);
        sessionRepository.DidNotReceive().Add(Arg.Any<Session>());
    }

    [Fact]
    public void StartUserSession_Should_ReturnUnauthorized_When_InvalidPinCode()
    {
        // arrange
        IAdminCredentialsValidator adminValidator = Substitute.For<IAdminCredentialsValidator>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var sessionsService = new SessionsService(adminValidator, sessionRepository, accountRepository);
        var accountName = new AccountName("TestAccount");
        var account = new Account(accountName, new PinCode("1234"), new Money(100));

        accountRepository.GetByName(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(account);

        // act
        CreateSessionResponse result = sessionsService.StartUserSession("TestAccount", "9999");

        // assert
        Assert.IsType<CreateSessionResponse.Unauthorized>(result);
        sessionRepository.DidNotReceive().Add(Arg.Any<Session>());
    }

    [Fact]
    public void StartUserSession_Should_ReturnSuccess_When_ValidCredentials()
    {
        // arrange
        IAdminCredentialsValidator adminValidator = Substitute.For<IAdminCredentialsValidator>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        var sessionsService = new SessionsService(adminValidator, sessionRepository, accountRepository);
        var accountName = new AccountName("TestAccount");
        var pinCode = new PinCode("1234");
        var account = new Account(accountName, pinCode, new Money(100));

        accountRepository.GetByName(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(account);

        // act
        CreateSessionResponse result = sessionsService.StartUserSession("TestAccount", "1234");

        // assert
        Assert.IsType<CreateSessionResponse.Success>(result);
        var success = (CreateSessionResponse.Success)result;
        Assert.NotEqual(Guid.Empty, success.SessionGuid);
        sessionRepository.Received(1).Add(Arg.Is<Session.UserSession>(s =>
            s.Id == success.SessionGuid &&
            s.AccountName.Value == "TestAccount"));
    }
}

