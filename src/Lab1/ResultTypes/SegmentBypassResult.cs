using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.BypassErrors;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record SegmentBypassResult
{
    private SegmentBypassResult() { }

    public sealed record Success(Time TimeTaken) : SegmentBypassResult;

    public sealed record Failure(IBypassError Error) : SegmentBypassResult;
}