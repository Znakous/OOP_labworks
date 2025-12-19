using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Path = Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;

public class RelativePriorityStrategy : RelativeStrategyBase
{
    private readonly IPath _root;

    private readonly IFileSystem _pathValidator;

    public RelativePriorityStrategy(IPath root, IFileSystem pathValidator)
    {
        _root = root;
        _pathValidator = pathValidator;
    }

    public override IPath CreatePath(IEnumerable<string> pathSegments)
    {
        IPath relativePath = new Path.RelativePath(_root.AsSegments.Concat(pathSegments));
        IPath commonPath = new Path.AbsolutePath(pathSegments);
        return GetBestMatch(relativePath, commonPath);
    }

    public override IEnumerable<string> GetPathSegments(IPath path)
    {
        IPath relativePath = new Path.RelativePath(GetAfterCommonPrefix(path.AsSegments, _root.AsSegments));
        return GetBestMatch(relativePath, path).AsSegments;
    }

    private IPath GetBestMatch(IPath relative, IPath absolute)
    {
        return _pathValidator.Exists(relative)
            ? relative
            : absolute;
    }
}