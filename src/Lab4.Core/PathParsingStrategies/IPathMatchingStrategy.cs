using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;

public interface IPathMatchingStrategy
{
    IPath CreatePath(IEnumerable<string> pathSegments);

    IEnumerable<string> GetPathSegments(IPath path);
}