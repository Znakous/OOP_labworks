using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

public abstract record FileSystemInteractionResult
{
    public sealed record Success() : FileSystemInteractionResult;

    public sealed record Failure(IError Error) : FileSystemInteractionResult;
}