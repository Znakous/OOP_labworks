using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;

public interface IPathMatchingStrategy
{
    IPath MatchPath(IPath path);
}