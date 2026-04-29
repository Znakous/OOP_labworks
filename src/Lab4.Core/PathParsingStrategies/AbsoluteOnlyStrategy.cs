using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Path = Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;

public class AbsoluteOnlyStrategy : IPathMatchingStrategy
{
    public IPath CreatePath(IEnumerable<string> pathSegments)
    {
        return new Path.AbsolutePath(pathSegments);
    }

    public IEnumerable<string> GetPathSegments(IPath path)
    {
        return path.AsSegments;
    }
}