using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

public abstract record GetFileContentResult
{
    public sealed record Success(string Content) : GetFileContentResult;

    public sealed record Failure(IError Error) : GetFileContentResult;
}