using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public record PowerPath(Coordinate Length, Force ForceApplied) : IRoutePart
{
    public PassResult ByPass(IMovingObj obj)
    {
        if (!obj.TryApplyForce(ForceApplied))
        {
            return new PassResult.Failure.ForceThresholdExceeded();
        }

        Time? timeTaken = obj.CountTime(Length);

        obj.TryApplyForce(new Force(0));

        return timeTaken == null
            ? new PassResult.Failure.InsufficientSpeed()
            : new PassResult.Success(timeTaken);
    }
}