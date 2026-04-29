using Abstractions.Repositories;
using Application.Services;
using Contracts.Responses;
using Domain.Entities;
using Domain.Models;
using Domain.Models.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BankAccountServiceTests
{
    [Fact]
    public void CheckBalance_Should_ReturnBadRequest_When_AccountNotFound()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankAccountService = new BankAccountService(accountRepository, transactionRepository);
        var accountName = new AccountName("TestAccount");

        accountRepository.GetByName(accountName).Returns((Account?)null);

        // act
        BalanceResponse result = bankAccountService.CheckBalance(accountName);

        // assert
        Assert.IsType<BalanceResponse.BadRequest>(result);
        var badRequest = (BalanceResponse.BadRequest)result;
        Assert.Equal("Account not found", badRequest.ErrorMessage);
    }

    [Fact]
    public void CheckBalance_Should_ReturnSuccess_When_AccountExists()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankAccountService = new BankAccountService(accountRepository, transactionRepository);
        var accountName = new AccountName("TestAccount");
        var account = new Account(accountName, new PinCode("1234"), new Money(500));

        accountRepository.GetByName(accountName).Returns(account);

        // act
        BalanceResponse result = bankAccountService.CheckBalance(accountName);

        // assert
        Assert.IsType<BalanceResponse.Success>(result);
        var success = (BalanceResponse.Success)result;
        Assert.Equal(500, success.Balance);
        transactionRepository.Received(1).Add(accountName, Arg.Any<ExecutedTransaction>());
    }

    [Fact]
    public void Deposit_Should_ReturnBadRequest_When_AccountNotFound()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankAccountService = new BankAccountService(accountRepository, transactionRepository);
        var accountName = new AccountName("TestAccount");
        var amount = new Money(100);

        accountRepository.GetByName(accountName).Returns((Account?)null);

        // act
        DepositResponse result = bankAccountService.Deposit(accountName, amount);

        // assert
        Assert.IsType<DepositResponse.BadRequest>(result);
        var badRequest = (DepositResponse.BadRequest)result;
        Assert.Equal("Account not found", badRequest.ErrorMessage);
    }

    [Fact]
    public void Deposit_Should_ReturnSuccess_And_IncreaseBalance_When_ValidData()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankAccountService = new BankAccountService(accountRepository, transactionRepository);
        var accountName = new AccountName("TestAccount");
        var account = new Account(accountName, new PinCode("1234"), new Money(500));
        var amount = new Money(100);

        accountRepository.GetByName(accountName).Returns(account);

        // act
        DepositResponse result = bankAccountService.Deposit(accountName, amount);

        // assert
        Assert.IsType<DepositResponse.Success>(result);
        var success = (DepositResponse.Success)result;
        Assert.NotNull(success.Transaction);
        Assert.Equal(600, account.Balance.Value);
        transactionRepository.Received(1).Add(accountName, Arg.Any<ExecutedTransaction>());
    }

    [Fact]
    public void Withdraw_Should_ReturnBadRequest_When_AccountNotFound()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankAccountService = new BankAccountService(accountRepository, transactionRepository);
        var accountName = new AccountName("TestAccount");
        var amount = new Money(100);

        accountRepository.GetByName(accountName).Returns((Account?)null);

        // act
        WithdrawResponse result = bankAccountService.Withdraw(accountName, amount);

        // assert
        Assert.IsType<WithdrawResponse.BadRequest>(result);
        var badRequest = (WithdrawResponse.BadRequest)result;
        Assert.Equal("Account not found", badRequest.ErrorMessage);
    }

    [Fact]
    public void Withdraw_Should_ReturnBadRequest_When_InsufficientBalance()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankAccountService = new BankAccountService(accountRepository, transactionRepository);
        var accountName = new AccountName("TestAccount");
        var account = new Account(accountName, new PinCode("1234"), new Money(50));
        var amount = new Money(100);

        accountRepository.GetByName(accountName).Returns(account);

        // act
        WithdrawResponse result = bankAccountService.Withdraw(accountName, amount);

        // assert
        Assert.IsType<WithdrawResponse.BadRequest>(result);
        var badRequest = (WithdrawResponse.BadRequest)result;
        Assert.Equal(50m, account.Balance.Value); // Balance should not change
    }

    [Fact]
    public void Withdraw_Should_ReturnSuccess_And_DecreaseBalance_When_ValidData()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankAccountService = new BankAccountService(accountRepository, transactionRepository);
        var accountName = new AccountName("TestAccount");
        var account = new Account(accountName, new PinCode("1234"), new Money(500));
        var amount = new Money(100);

        accountRepository.GetByName(accountName).Returns(account);

        // act
        WithdrawResponse result = bankAccountService.Withdraw(accountName, amount);

        // assert
        Assert.IsType<WithdrawResponse.Success>(result);
        var success = (WithdrawResponse.Success)result;
        Assert.NotNull(success.Transaction);
        Assert.Equal(400, account.Balance.Value);
        transactionRepository.Received(1).Add(accountName, Arg.Any<ExecutedTransaction>());
    }

    [Fact]
    public void Withdraw_Should_ReturnSuccess_When_BalanceEqualsAmount()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IExecutedTransactionRepository transactionRepository = Substitute.For<IExecutedTransactionRepository>();
        var bankAccountService = new BankAccountService(accountRepository, transactionRepository);
        var accountName = new AccountName("TestAccount");
        var account = new Account(accountName, new PinCode("1234"), new Money(100));
        var amount = new Money(100);

        accountRepository.GetByName(accountName).Returns(account);

        // act
        WithdrawResponse result = bankAccountService.Withdraw(accountName, amount);

        // assert
        Assert.IsType<WithdrawResponse.Success>(result);
        Assert.Equal(0, account.Balance.Value);
    }
}

