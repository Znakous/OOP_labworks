using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.PassErrors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public struct PowerPath : IRoutePart
{
    private readonly Distance _length;
    private readonly Force _forceApplied;

    public PowerPath(Distance length, Force forceApplied)
    {
        _length = length;
        _forceApplied = forceApplied;
    }

    public PassResult ByPass(Train train)
    {
        if (!train.TryApplyForce(_forceApplied))
        {
            return new PassResult.Failure(new ForceThresholdExceeded("Power path pushed to hard"));
        }

        TrainMoveResult moveResult = train.Move(_length);

        train.TryApplyForce(Force.Zero());

        return (moveResult is TrainMoveResult.Success success)
            ? new PassResult.Success(success.TimeTaken)
            : new PassResult.Failure(new InsufficientSpeed("Stopped on power path"));
    }
}