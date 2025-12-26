using Abstractions.Repositories;
using Application.Extentions;
using Contracts.Responses;
using Domain.Entities;
using Domain.Entities.Transactions;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.ResultTypes;
using Domain.Models.ValueObjects;
using System.Diagnostics;

namespace Application.Services;

public class BankAccountService
{
    private readonly IAccountRepository _accountRepository;

    private readonly IExecutedTransactionRepository _executedTransactionRepository;

    public BankAccountService(
        IAccountRepository accountRepository,
        IExecutedTransactionRepository executedTransactionRepository)
    {
        _accountRepository = accountRepository;
        _executedTransactionRepository = executedTransactionRepository;
    }

    public BalanceResponse CheckBalance(AccountName accountName)
    {
        TransactionPerformingResult result = PerformTransaction(accountName, new BalanceCheck());
        if (result is TransactionPerformingResult.Failure failure)
        {
            return new BalanceResponse.BadRequest(failure.ErrorMessage);
        }

        Account? account = _accountRepository.GetByName(accountName);
        return account is null
            ? new BalanceResponse.BadRequest("Account not found")
            : new BalanceResponse.Success(account.Balance.Value);
    }

    public DepositResponse Deposit(AccountName accountName, Money amount)
    {
        TransactionPerformingResult result = PerformTransaction(accountName, new Deposit(amount));
        if (result is TransactionPerformingResult.Failure failure)
        {
            return new DepositResponse.BadRequest(failure.ErrorMessage);
        }

        if (result is TransactionPerformingResult.Success success)
        {
            return new DepositResponse.Success(TransactionsExtensions.MapToDto(success.Transaction));
        }

        throw new UnreachableException();
    }

    public WithdrawResponse Withdraw(AccountName accountName, Money amount)
    {
        TransactionPerformingResult result = PerformTransaction(accountName, new Withdraw(amount));
        if (result is TransactionPerformingResult.Failure failure)
        {
            return new WithdrawResponse.BadRequest(failure.ErrorMessage);
        }

        if (result is TransactionPerformingResult.Success success)
        {
            return new WithdrawResponse.Success(TransactionsExtensions.MapToDto(success.Transaction));
        }

        throw new UnreachableException();
    }

    private record TransactionPerformingResult()
    {
        public record Success(ExecutedTransaction Transaction) : TransactionPerformingResult();

        public record Failure(string ErrorMessage) : TransactionPerformingResult();
    }

    private TransactionPerformingResult PerformTransaction<TTransaction>(AccountName accountName, TTransaction transaction) where TTransaction : ITransaction
    {
        Account? account = _accountRepository.GetByName(accountName);
        if (account is null)
        {
            return new TransactionPerformingResult.Failure("Account not found");
        }

        TransactionExecutionResult executionResult = transaction.Execute(account);
        if (executionResult is TransactionExecutionResult.Failure failure)
        {
            return new TransactionPerformingResult.Failure(failure.Error.Message);
        }

        if (executionResult is TransactionExecutionResult.Success success)
        {
            _executedTransactionRepository.Add(accountName, success.ExecutedTransaction);
            return new TransactionPerformingResult.Success(success.ExecutedTransaction);
        }

        throw new UnreachableException();
    }
}