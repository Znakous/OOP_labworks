using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FIleSystemIterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

public abstract record GetIteratorResult
{
    public sealed record Success(IFileSystemIterator Iterator) : GetIteratorResult;

    public sealed record Failure(IError Error) : GetIteratorResult;
}