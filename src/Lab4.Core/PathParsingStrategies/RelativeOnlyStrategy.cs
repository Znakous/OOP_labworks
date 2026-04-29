using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Path = Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;

public class RelativeOnlyStrategy : RelativeStrategyBase
{
    private readonly IPath _root;

    public RelativeOnlyStrategy(IPath root)
    {
        _root = root;
    }

    public override IPath CreatePath(IEnumerable<string> pathSegments)
    {
        return new Path.RelativePath(_root.AsSegments.Concat(pathSegments));
    }

    public override IEnumerable<string> GetPathSegments(IPath path)
    {
        return GetAfterCommonPrefix(path.AsSegments, _root.AsSegments);
    }
}