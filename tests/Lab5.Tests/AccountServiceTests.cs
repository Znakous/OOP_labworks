using Abstractions.Repositories;
using Application.Services;
using Contracts.Responses;
using Domain.Entities;
using Domain.Models.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class AccountServiceTests
{
    [Fact]
    public void CreateAccount_Should_ReturnBadRequest_When_SessionNotFound()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        var accountService = new AccountService(accountRepository, sessionRepository);
        var sessionId = Guid.NewGuid();

        sessionRepository.GetById(sessionId).Returns((Session?)null);

        // act
        CreateAccountResponse result = accountService.CreateAccount("TestAccount", "1234", 100, sessionId);

        // assert
        Assert.IsType<CreateAccountResponse.BadRequest>(result);
        var badRequest = (CreateAccountResponse.BadRequest)result;
        Assert.Equal("Session not found", badRequest.ErrorMessage);
    }

    [Fact]
    public void CreateAccount_Should_ReturnUnauthorised_When_SessionIsNotAdmin()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        var accountService = new AccountService(accountRepository, sessionRepository);
        var sessionId = Guid.NewGuid();
        var accountName = new AccountName("TestAccount");
        var userSession = new Session.UserSession(sessionId, accountName, DateTime.Now);

        sessionRepository.GetById(sessionId).Returns(userSession);

        // act
        CreateAccountResponse result = accountService.CreateAccount("TestAccount", "1234", 100, sessionId);

        // assert
        Assert.IsType<CreateAccountResponse.Unauthorised>(result);
        var unauthorised = (CreateAccountResponse.Unauthorised)result;
        Assert.Equal("Session isn't an admin one", unauthorised.ErrorMessage);
    }

    [Fact]
    public void CreateAccount_Should_ReturnBadRequest_When_AccountAlreadyExists()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        var accountService = new AccountService(accountRepository, sessionRepository);
        var sessionId = Guid.NewGuid();
        var adminSession = new Session.AdminSession(sessionId, DateTime.Now);
        var accountName = new AccountName("TestAccount");
        var existingAccount = new Account(accountName, new PinCode("1234"), new Money(100));

        sessionRepository.GetById(sessionId).Returns(adminSession);
        accountRepository.GetByName(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(existingAccount);

        // act
        CreateAccountResponse result = accountService.CreateAccount("TestAccount", "1234", 100, sessionId);

        // assert
        Assert.IsType<CreateAccountResponse.BadRequest>(result);
        var badRequest = (CreateAccountResponse.BadRequest)result;
        Assert.Equal("Account already exists", badRequest.ErrorMessage);
    }

    [Fact]
    public void CreateAccount_Should_ReturnSuccess_When_ValidData()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        var accountService = new AccountService(accountRepository, sessionRepository);
        var sessionId = Guid.NewGuid();
        var adminSession = new Session.AdminSession(sessionId, DateTime.Now);

        sessionRepository.GetById(sessionId).Returns(adminSession);
        accountRepository.GetByName(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns((Account?)null);

        // act
        CreateAccountResponse result = accountService.CreateAccount("TestAccount", "1234", 100, sessionId);

        // assert
        Assert.IsType<CreateAccountResponse.Success>(result);
        accountRepository.Received(1).Add(Arg.Is<Account>(a =>
            a.Name.Value == "TestAccount" &&
            a.Pin.Value == "1234" &&
            a.Balance.Value == 100));
    }
}

