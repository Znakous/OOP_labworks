using Domain.Interfaces;

namespace Domain.Models.ResultTypes;

public abstract record TransactionExecutionResult
{
    public sealed record Success(ExecutedTransaction ExecutedTransaction) : TransactionExecutionResult;

    public sealed record Failure(IError Error) : TransactionExecutionResult;
}