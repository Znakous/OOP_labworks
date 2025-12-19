namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathBuildingStrategies;

public interface IPathBuildingStrategy
{
    IEnumerable<string> SplitPath(string path);

    string BuildPath(IEnumerable<string> pathSegments);
}