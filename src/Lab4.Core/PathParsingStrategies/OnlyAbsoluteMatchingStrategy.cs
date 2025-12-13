using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;

public class OnlyAbsoluteMatchingStrategy : IPathMatchingStrategy
{
    public IPath MatchPath(IPath path)
    {
        return path;
    }
}