namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathBuildingStrategies;

public class UnixPathBuildingStrategy : IPathBuildingStrategy
{
    private const char _delimiter = '/';

    public string BuildPath(IEnumerable<string> pathSegments)
    {
        return string.Join(_delimiter, pathSegments);
    }

    public IEnumerable<string> SplitPath(string path)
    {
        var stack = new Stack<string>();
        foreach (string element in path.Split(_delimiter))
        {
            if (element == ".")
            {
                continue;
            }

            if (element == ".." && stack.Count != 0)
            {
                stack.Pop();
            }

            stack.Push(element);
        }

        return stack.Reverse();
    }
}