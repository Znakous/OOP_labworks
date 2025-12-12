using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathValidators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;

public class RelativePriorityStrategy : IPathMatchingStrategy
{
    private readonly IPath _root;

    private readonly IPathValidator _pathValidator;

    public RelativePriorityStrategy(IPath root, IPathValidator pathValidator)
    {
        _root = root;
        _pathValidator = pathValidator;
    }

    public IPath MatchPath(IPath path)
    {
        IPath relativePath = _root.ExtendedWith(path);
        return GetBestMatch(relativePath, path);
    }

    private IPath GetBestMatch(IPath relative, IPath absolute)
    {
        return _pathValidator.IsValidPath(relative)
            ? relative
            : absolute;
    }
}