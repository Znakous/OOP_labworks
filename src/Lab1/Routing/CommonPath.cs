using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public record CommonPath(Coordinate Length) : IRoutePart
{
    public PassResult ByPass(IMovingObj obj)
    {
        Time? timeTaken = obj.CountTime(Length);

        return timeTaken == null
            ? new PassResult.Failure.InsufficientSpeed()
            : new PassResult.Success(timeTaken);
    }
}