using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public record EndPoint(Speed SpeedLimit) : IRoutePart
{
    public PassResult ByPass(IMovingObj obj)
    {
        return (obj.ObjSpeed > SpeedLimit)
            ? new PassResult.Failure.SpeedLimitExceeded()
            : new PassResult.Success(new Time(0));
    }
}