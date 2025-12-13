using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathHandlers;

public interface IPathHandler
{
    string MakePath(IPath path);

    IPath ParsePath(string pathString);
}