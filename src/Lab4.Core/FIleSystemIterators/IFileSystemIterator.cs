using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FIleSystemIterators;

public interface IFileSystemIterator
{
    IFileSystemObject Current();

    bool MoveTo(IPath newPath);
}