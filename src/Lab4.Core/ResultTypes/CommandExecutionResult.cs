using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

public abstract record CommandExecutionResult
{
    public sealed record Succes() : CommandExecutionResult;

    public sealed record Failure(IError Error) : CommandExecutionResult;
}