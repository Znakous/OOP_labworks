using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.BypassErrors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public class CommonPath : IRoutePart
{
    private readonly Distance _length;

    public CommonPath(Distance length)
    {
        _length = length;
    }

    public SegmentBypassResult ByPass(Train train)
    {
        TrainMoveResult moveResult = train.Move(_length);

        return (moveResult is TrainMoveResult.Success success)
            ? new SegmentBypassResult.Success(success.TimeTaken)
            : new SegmentBypassResult.Failure(new InsufficientSpeed("Stopped on common path"));
    }
}