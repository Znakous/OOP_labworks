namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.PathHandlers;

public interface IPathHandler
{
    string MakePath(IPath path);

    IPath ParsePath(string pathString);
}