using Itmo.ObjectOrientedProgramming.Lab4.Core.PathBuildingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsers;

public class PathParser : IPathParser
{
    private readonly IPathBuildingStrategy _buildingStrategy;

    public PathParser(IPathBuildingStrategy buildingStrategy)
    {
        _buildingStrategy = buildingStrategy;
    }

    public IPath ParsePath(string pathString, IPathMatchingStrategy inputStrategy)
    {
        return inputStrategy.CreatePath(_buildingStrategy.SplitPath(pathString));
    }
}