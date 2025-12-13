using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Path = Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathHandlers;

public class UnixPathHandler : IPathHandler
{
    private const char _delimiter = '/';

    public string MakePath(IPath path)
    {
        return string.Join(_delimiter, path);
    }

    public IPath ParsePath(string pathString)
    {
        var stack = new Stack<string>();
        foreach (string element in pathString.Split(_delimiter))
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

        return new Path(stack);
    }
}