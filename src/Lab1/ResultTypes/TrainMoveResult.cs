using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes.TrainErrors;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record TrainMoveResult
{
    private TrainMoveResult() { }

    public sealed record Success(Time TimeTaken) : TrainMoveResult;

    public sealed record Failure(ITrainError Error) : TrainMoveResult;
}