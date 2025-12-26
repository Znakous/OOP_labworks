using Abstractions.Repositories;
using Application.Services;
using Contracts.Responses;
using Domain.Entities;
using Domain.Models;
using Domain.Models.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TransactionHistoryServiceTests
{
    [Fact]
    public void History_Should_ReturnBadRequest_When_SessionNotFound()
    {
        // arrange
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        var transactionHistoryService = new TransactionHistoryService(transactionRepository, sessionRepository);
        var sessionId = Guid.NewGuid();

        sessionRepository.GetById(sessionId).Returns((Session?)null);

        // act
        TransactionHistoryResponse result = transactionHistoryService.History("TestAccount", sessionId);

        // assert
        Assert.IsType<TransactionHistoryResponse.BadRequest>(result);
        var badRequest = (TransactionHistoryResponse.BadRequest)result;
        Assert.Equal("Session not found", badRequest.ErrorMessage);
    }

    [Fact]
    public void History_Should_ReturnUnauthorised_When_UserSessionAccountMismatch()
    {
        // arrange
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        var transactionHistoryService = new TransactionHistoryService(transactionRepository, sessionRepository);
        var sessionId = Guid.NewGuid();
        var userAccountName = new AccountName("UserAccount");
        var userSession = new Session.UserSession(sessionId, userAccountName, DateTime.Now);

        sessionRepository.GetById(sessionId).Returns(userSession);

        // act
        TransactionHistoryResponse result = transactionHistoryService.History("TestAccount", sessionId);

        // assert
        Assert.IsType<TransactionHistoryResponse.Unauthorised>(result);
        var unauthorised = (TransactionHistoryResponse.Unauthorised)result;
        Assert.Equal("Account doesn't belong to this session", unauthorised.ErrorMessage);
    }

    [Fact]
    public void History_Should_ReturnBadRequest_When_AccountNotFound()
    {
        // arrange
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        var transactionHistoryService = new TransactionHistoryService(transactionRepository, sessionRepository);
        var sessionId = Guid.NewGuid();
        var adminSession = new Session.AdminSession(sessionId, DateTime.Now);

        sessionRepository.GetById(sessionId).Returns(adminSession);
        transactionRepository.GetForAccount(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns((IEnumerable<ExecutedTransaction>?)null);

        // act
        TransactionHistoryResponse result = transactionHistoryService.History("TestAccount", sessionId);

        // assert
        Assert.IsType<TransactionHistoryResponse.BadRequest>(result);
        var badRequest = (TransactionHistoryResponse.BadRequest)result;
        Assert.Equal("Account not found", badRequest.ErrorMessage);
    }

    [Fact]
    public void History_Should_ReturnSuccess_When_AdminSession()
    {
        // arrange
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        var transactionHistoryService = new TransactionHistoryService(transactionRepository, sessionRepository);
        var sessionId = Guid.NewGuid();
        var adminSession = new Session.AdminSession(sessionId, DateTime.Now);
        var transactions = new List<ExecutedTransaction>
        {
            new("Deposit", DateTime.Now.AddHours(-2), new Money(100), new Money(200)),
            new("Withdraw", DateTime.Now.AddHours(-1), new Money(200), new Money(150)),
        };

        sessionRepository.GetById(sessionId).Returns(adminSession);
        transactionRepository.GetForAccount(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(transactions);

        // act
        TransactionHistoryResponse result = transactionHistoryService.History("TestAccount", sessionId);

        // assert
        Assert.IsType<TransactionHistoryResponse.Success>(result);
        var success = (TransactionHistoryResponse.Success)result;
        Assert.Equal(2, success.Transactions.Count());
    }

    [Fact]
    public void History_Should_ReturnSuccess_When_UserSessionOwnsAccount()
    {
        // arrange
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        var transactionHistoryService = new TransactionHistoryService(transactionRepository, sessionRepository);
        var sessionId = Guid.NewGuid();
        var accountName = new AccountName("TestAccount");
        var userSession = new Session.UserSession(sessionId, accountName, DateTime.Now);
        var transactions = new List<ExecutedTransaction>
        {
            new("Deposit", DateTime.Now.AddHours(-2), new Money(100), new Money(200)),
        };

        sessionRepository.GetById(sessionId).Returns(userSession);
        transactionRepository.GetForAccount(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(transactions);

        // act
        TransactionHistoryResponse result = transactionHistoryService.History("TestAccount", sessionId);

        // assert
        Assert.IsType<TransactionHistoryResponse.Success>(result);
        var success = (TransactionHistoryResponse.Success)result;
        Assert.Single(success.Transactions);
    }

    [Fact]
    public void History_Should_ReturnEmptyList_When_NoTransactions()
    {
        // arrange
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        ISessionRepository sessionRepository = Substitute.For<ISessionRepository>();
        var transactionHistoryService = new TransactionHistoryService(transactionRepository, sessionRepository);
        var sessionId = Guid.NewGuid();
        var adminSession = new Session.AdminSession(sessionId, DateTime.Now);
        var emptyTransactions = new List<ExecutedTransaction>();

        sessionRepository.GetById(sessionId).Returns(adminSession);
        transactionRepository.GetForAccount(Arg.Is<AccountName>(x => x.Value == "TestAccount")).Returns(emptyTransactions);

        // act
        TransactionHistoryResponse result = transactionHistoryService.History("TestAccount", sessionId);

        // assert
        Assert.IsType<TransactionHistoryResponse.Success>(result);
        var success = (TransactionHistoryResponse.Success)result;
        Assert.Empty(success.Transactions);
    }
}

