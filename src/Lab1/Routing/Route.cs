using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.BypassErrors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public class Route
{
    private readonly IEnumerable<IRoutePart> _routeParts;

    private readonly Speed _stoppingCapability;

    public Route(IEnumerable<IRoutePart> routeParts, Speed stoppingCapability)
    {
        _routeParts = routeParts;
        _stoppingCapability = stoppingCapability;
    }

    public RouteBypassResult ByPass(Train train)
    {
        var curTime = Time.Zero();
        foreach (IRoutePart part in _routeParts)
        {
            SegmentBypassResult result = part.ByPass(train);
            if (result is SegmentBypassResult.Failure failure)
            {
                return new RouteBypassResult.Failure(failure.Error, part);
            }

            var success = (SegmentBypassResult.Success)result;
            curTime += success.TimeTaken;
        }

        return train.CurSpeed <= _stoppingCapability
            ? new RouteBypassResult.Success(curTime)
            : new RouteBypassResult.Failure(new SpeedLimitExceeded("Route endpoint couldn't stop train"), null);
    }
}