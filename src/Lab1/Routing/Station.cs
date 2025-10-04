using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.PassErrors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public struct Station : IRoutePart
{
    private readonly Speed _speedLimit;
    private readonly Time _timeToBoard;

    public Station(Speed speedLimit, Time timeToBoard)
    {
        _timeToBoard = timeToBoard;
        _speedLimit = speedLimit;
    }

    public PassResult ByPass(Train train)
    {
        return train.CurSpeed > _speedLimit
            ? new PassResult.Failure(new SpeedLimitExceeded("Station couldn't stop train"))
            : new PassResult.Success(_timeToBoard);
    }
}