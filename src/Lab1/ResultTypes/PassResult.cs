using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;

namespace Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

public abstract record PassResult
{
    private PassResult() { }

    public sealed record Success(Time TimeTaken) : PassResult;

    public abstract record Failure : PassResult
    {
        private Failure() { }

        public sealed record InsufficientSpeed : PassResult;

        public sealed record ForceThresholdExceeded : PassResult;

        public sealed record SpeedLimitExceeded : PassResult;

        public sealed record BadRouteOrdering : PassResult;
    }
}