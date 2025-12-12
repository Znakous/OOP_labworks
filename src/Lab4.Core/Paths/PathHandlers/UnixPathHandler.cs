namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.PathHandlers;

public class UnixPathHandler : IPathHandler
{
    private const char _delimiter = '/';

    public string MakePath(IPath path)
    {
        return string.Join(_delimiter, path);
    }

    public IPath ParsePath(string pathString)
    {
        return new Path(pathString.Split(_delimiter));
    }
}