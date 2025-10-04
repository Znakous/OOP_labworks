using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.PassErrors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public record CommonPath(Distance Length) : IRoutePart
{
    public PassResult ByPass(Train train)
    {
        TrainMoveResult moveResult = train.Move(Length);

        return (moveResult is TrainMoveResult.Success success)
            ? new PassResult.Success(success.TimeTaken)
            : new PassResult.Failure(new InsufficientSpeed("Stopped on common path"));
    }
}