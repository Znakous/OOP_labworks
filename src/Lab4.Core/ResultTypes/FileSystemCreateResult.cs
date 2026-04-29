using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

public abstract record FileSystemCreateResult
{
    public sealed record Success(IFileSystem FileSystem) : FileSystemCreateResult;

    public sealed record Failure(IError Error) : FileSystemCreateResult;
}