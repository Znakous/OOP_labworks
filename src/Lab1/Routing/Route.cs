using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.PassErrors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public struct Route
{
    private readonly IEnumerable<IRoutePart> _routeParts;

    private readonly Speed _stoppingCapability;

    public Route(IEnumerable<IRoutePart> routeParts, Speed stoppingCapability)
    {
        _routeParts = routeParts;
        _stoppingCapability = stoppingCapability;
    }

    public PassResult ByPass(Train train)
    {
        var curTime = Time.Zero();
        foreach (IRoutePart part in _routeParts)
        {
            PassResult result = part.ByPass(train);
            if (result is not PassResult.Success success)
            {
                return result;
            }

            curTime += success.TimeTaken;
        }

        return train.CurSpeed <= _stoppingCapability
            ? new PassResult.Success(curTime)
            : new PassResult.Failure(new SpeedLimitExceeded("Route endpoint couldn't stop train"));
    }
}