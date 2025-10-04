using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.BypassErrors;
using Itmo.ObjectOrientedProgramming.Lab1.Routing;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record RouteBypassResult
{
    private RouteBypassResult() { }

    public sealed record Success(Time TimeTaken) : RouteBypassResult;

    public sealed record Failure(IBypassError Error, IRoutePart? RoutePart) : RouteBypassResult;
}