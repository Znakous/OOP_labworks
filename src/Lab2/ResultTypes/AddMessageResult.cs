using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.AddMessageErrors;

namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record AddMessageResult()
{
    public sealed record Success() : AddMessageResult();

    public sealed record Failure(IMessageAddError Error) : AddMessageResult();
}