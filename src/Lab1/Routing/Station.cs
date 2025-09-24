using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public record Station(Speed SpeedLimit, Time TimeToBoard) : IRoutePart
{
    public PassResult ByPass(IMovingObj obj)
    {
        if (obj.ObjSpeed > SpeedLimit)
            return new PassResult.Failure.SpeedLimitExceeded();

        return new PassResult.Success(TimeToBoard);
    }
}