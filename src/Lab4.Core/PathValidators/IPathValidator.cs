using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathValidators;

public interface IPathValidator
{
    bool IsValidPath(IPath path);

    bool IsDirectory(IPath path);
}