using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.PassErrors;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record PassResult
{
    private PassResult() { }

    public sealed record Success(Time TimeTaken) : PassResult;

    public sealed record Failure(IPassError Error) : PassResult;
}