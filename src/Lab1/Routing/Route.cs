using Itmo.ObjectOrientedProgramming.Lab1.MovingObjects;
using Itmo.ObjectOrientedProgramming.Lab1.PhysicalValues;
using Itmo.ObjectOrientedProgramming.Lab1.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routing;

public record Route(IEnumerable<IRoutePart> RouteParts)
{
    public PassResult ByPass(IMovingObj movingObj)
    {
        var curTime = new Time(0);
        bool endReached = false;
        foreach (IRoutePart part in RouteParts)
        {
            if (part is EndPoint)
            {
                if (endReached)
                    return new PassResult.Failure.BadRouteOrdering();
                endReached = true;
            }

            PassResult result = part.ByPass(movingObj);
            if (result is not PassResult.Success success)
            {
                return result;
            }

            curTime += success.TimeTaken;
        }

        return endReached
            ? new PassResult.Success(curTime)
            : new PassResult.Failure.BadRouteOrdering();
    }
}