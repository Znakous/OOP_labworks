using Itmo.ObjectOrientedProgramming.Lab4.Core.PathBuildingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathCreators;

public class AbsolutePathCreator : IPathCreator
{
    private readonly IPathBuildingStrategy _buildingStrategy;

    public AbsolutePathCreator(IPathBuildingStrategy buildingStrategy)
    {
        _buildingStrategy = buildingStrategy;
    }

    public string BuildPath(IPath path, IPathMatchingStrategy strategy)
    {
        return _buildingStrategy.BuildPath(strategy.GetPathSegments(path));
    }
}