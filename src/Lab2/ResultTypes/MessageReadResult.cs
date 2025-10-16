using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.ReadMessageErrors;

namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record MessageReadResult
{
    public sealed record Success() : MessageReadResult();

    public sealed record Failure(IReadMessageError Error) : MessageReadResult();
}