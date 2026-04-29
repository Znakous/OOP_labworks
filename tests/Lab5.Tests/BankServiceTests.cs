using Abstractions.Repositories;
using Application.Services;
using Contracts.Responses;
using Domain.Entities;
using Domain.Models.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankServiceTests
{
    [Fact]
    public void CheckBalance_Should_ReturnBadRequest_When_SessionNotFound()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankService = new BankService(accountRepository, sessionRepository, transactionRepository);
        var sessionId = Guid.NewGuid();

        sessionRepository.GetById(sessionId).Returns((Session?)null);

        // act
        BalanceResponse result = bankService.CheckBalance("TestAccount", sessionId);

        // assert
        Assert.IsType<BalanceResponse.BadRequest>(result);
        var badRequest = (BalanceResponse.BadRequest)result;
        Assert.Equal("Session not found", badRequest.ErrorMessage);
    }

    [Fact]
    public void CheckBalance_Should_ReturnUnauthorized_When_UserSessionAccountMismatch()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankService = new BankService(accountRepository, sessionRepository, transactionRepository);
        var sessionId = Guid.NewGuid();
        var userAccountName = new AccountName("UserAccount");
        var requestedAccountName = new AccountName("TestAccount");
        var userSession = new Session.UserSession(sessionId, userAccountName, DateTime.Now);
        var account = new Account(requestedAccountName, new PinCode("1234"), new Money(500));

        sessionRepository.GetById(sessionId).Returns(userSession);
        accountRepository.GetByName(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(account);

        // act
        BalanceResponse result = bankService.CheckBalance("TestAccount", sessionId);

        // assert
        Assert.IsType<BalanceResponse.Unauthorized>(result);
        var unauthorized = (BalanceResponse.Unauthorized)result;
        Assert.Equal("Account doesn't belong to this session", unauthorized.ErrorMessage);
    }

    [Fact]
    public void CheckBalance_Should_ReturnSuccess_When_AdminSession()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankService = new BankService(accountRepository, sessionRepository, transactionRepository);
        var sessionId = Guid.NewGuid();
        var adminSession = new Session.AdminSession(sessionId, DateTime.Now);
        var accountName = new AccountName("TestAccount");
        var account = new Account(accountName, new PinCode("1234"), new Money(500));

        sessionRepository.GetById(sessionId).Returns(adminSession);
        accountRepository.GetByName(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(account);

        // act
        BalanceResponse result = bankService.CheckBalance("TestAccount", sessionId);

        // assert
        Assert.IsType<BalanceResponse.Success>(result);
        var success = (BalanceResponse.Success)result;
        Assert.Equal(500, success.Balance);
    }

    [Fact]
    public void CheckBalance_Should_ReturnSuccess_When_UserSessionOwnsAccount()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankService = new BankService(accountRepository, sessionRepository, transactionRepository);
        var sessionId = Guid.NewGuid();
        var accountName = new AccountName("TestAccount");
        var userSession = new Session.UserSession(sessionId, accountName, DateTime.Now);
        var account = new Account(accountName, new PinCode("1234"), new Money(500));

        sessionRepository.GetById(sessionId).Returns(userSession);
        accountRepository.GetByName(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(account);

        // act
        BalanceResponse result = bankService.CheckBalance("TestAccount", sessionId);

        // assert
        Assert.IsType<BalanceResponse.Success>(result);
        var success = (BalanceResponse.Success)result;
        Assert.Equal(500, success.Balance);
    }

    [Fact]
    public void Deposit_Should_ReturnBadRequest_When_SessionNotFound()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankService = new BankService(accountRepository, sessionRepository, transactionRepository);
        var sessionId = Guid.NewGuid();

        sessionRepository.GetById(sessionId).Returns((Session?)null);

        // act
        DepositResponse result = bankService.Deposit("TestAccount", sessionId, 100);

        // assert
        Assert.IsType<DepositResponse.BadRequest>(result);
        var badRequest = (DepositResponse.BadRequest)result;
        Assert.Equal("Session not found", badRequest.ErrorMessage);
    }

    [Fact]
    public void Deposit_Should_ReturnUnauthorised_When_UserSessionAccountMismatch()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankService = new BankService(accountRepository, sessionRepository, transactionRepository);
        var sessionId = Guid.NewGuid();
        var userAccountName = new AccountName("UserAccount");
        var requestedAccountName = new AccountName("TestAccount");
        var userSession = new Session.UserSession(sessionId, userAccountName, DateTime.Now);
        var account = new Account(requestedAccountName, new PinCode("1234"), new Money(500));

        sessionRepository.GetById(sessionId).Returns(userSession);
        accountRepository.GetByName(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(account);

        // act
        DepositResponse result = bankService.Deposit("TestAccount", sessionId, 100);

        // assert
        Assert.IsType<DepositResponse.Unauthorised>(result);
        var unauthorised = (DepositResponse.Unauthorised)result;
        Assert.Equal("Account doesn't belong to this session", unauthorised.ErrorMessage);
    }

    [Fact]
    public void Deposit_Should_ReturnSuccess_When_AdminSession()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankService = new BankService(accountRepository, sessionRepository, transactionRepository);
        var sessionId = Guid.NewGuid();
        var adminSession = new Session.AdminSession(sessionId, DateTime.Now);
        var accountName = new AccountName("TestAccount");
        var account = new Account(accountName, new PinCode("1234"), new Money(500));

        sessionRepository.GetById(sessionId).Returns(adminSession);
        accountRepository.GetByName(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(account);

        // act
        DepositResponse result = bankService.Deposit("TestAccount", sessionId, 100);

        // assert
        Assert.IsType<DepositResponse.Success>(result);
        Assert.Equal(600, account.Balance.Value);
    }

    [Fact]
    public void Withdraw_Should_ReturnBadRequest_When_SessionNotFound()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankService = new BankService(accountRepository, sessionRepository, transactionRepository);
        var sessionId = Guid.NewGuid();

        sessionRepository.GetById(sessionId).Returns((Session?)null);

        // act
        WithdrawResponse result = bankService.Withdraw("TestAccount", sessionId, 100);

        // assert
        Assert.IsType<WithdrawResponse.BadRequest>(result);
        var badRequest = (WithdrawResponse.BadRequest)result;
        Assert.Equal("Session not found", badRequest.ErrorMessage);
    }

    [Fact]
    public void Withdraw_Should_ReturnUnauthorised_When_UserSessionAccountMismatch()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankService = new BankService(accountRepository, sessionRepository, transactionRepository);
        var sessionId = Guid.NewGuid();
        var userAccountName = new AccountName("UserAccount");
        var requestedAccountName = new AccountName("TestAccount");
        var userSession = new Session.UserSession(sessionId, userAccountName, DateTime.Now);
        var account = new Account(requestedAccountName, new PinCode("1234"), new Money(500));

        sessionRepository.GetById(sessionId).Returns(userSession);
        accountRepository.GetByName(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(account);

        // act
        WithdrawResponse result = bankService.Withdraw("TestAccount", sessionId, 100);

        // assert
        Assert.IsType<WithdrawResponse.Unauthorised>(result);
        var unauthorised = (WithdrawResponse.Unauthorised)result;
        Assert.Equal("Account doesn't belong to this session", unauthorised.ErrorMessage);
    }

    [Fact]
    public void Withdraw_Should_ReturnSuccess_When_AdminSession()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankService = new BankService(accountRepository, sessionRepository, transactionRepository);
        var sessionId = Guid.NewGuid();
        var adminSession = new Session.AdminSession(sessionId, DateTime.Now);
        var accountName = new AccountName("TestAccount");
        var account = new Account(accountName, new PinCode("1234"), new Money(500));

        sessionRepository.GetById(sessionId).Returns(adminSession);
        accountRepository.GetByName(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(account);

        // act
        WithdrawResponse result = bankService.Withdraw("TestAccount", sessionId, 100);

        // assert
        Assert.IsType<WithdrawResponse.Success>(result);
        Assert.Equal(400, account.Balance.Value);
    }

    [Fact]
    public void Withdraw_Should_ReturnBadRequest_When_InsufficientBalance()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankService = new BankService(accountRepository, sessionRepository, transactionRepository);
        var sessionId = Guid.NewGuid();
        var adminSession = new Session.AdminSession(sessionId, DateTime.Now);
        var accountName = new AccountName("TestAccount");
        var account = new Account(accountName, new PinCode("1234"), new Money(50));

        sessionRepository.GetById(sessionId).Returns(adminSession);
        accountRepository.GetByName(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(account);

        // act
        WithdrawResponse result = bankService.Withdraw("TestAccount", sessionId, 100);

        // assert
        Assert.IsType<WithdrawResponse.BadRequest>(result);
        var badRequest = (WithdrawResponse.BadRequest)result;
        Assert.Equal(50, account.Balance.Value);
    }
}

