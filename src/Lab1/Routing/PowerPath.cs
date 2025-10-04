using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.BypassErrors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public class PowerPath : IRoutePart
{
    private readonly Distance _length;
    private readonly Force _forceApplied;

    public PowerPath(Distance length, Force forceApplied)
    {
        _length = length;
        _forceApplied = forceApplied;
    }

    public SegmentBypassResult ByPass(Train train)
    {
        if (!train.TryApplyForce(_forceApplied))
        {
            return new SegmentBypassResult.Failure(new ForceThresholdExceeded("Power path pushed to hard"));
        }

        TrainMoveResult moveResult = train.Move(_length);

        train.TryApplyForce(Force.Zero());

        return (moveResult is TrainMoveResult.Success success)
            ? new SegmentBypassResult.Success(success.TimeTaken)
            : new SegmentBypassResult.Failure(new InsufficientSpeed("Stopped on power path"));
    }
}