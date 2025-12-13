using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public abstract record CommandCreateResult
{
    public sealed record Success(ICommand Command) : CommandCreateResult;

    public sealed record Failure(IError Error) : CommandCreateResult;
}