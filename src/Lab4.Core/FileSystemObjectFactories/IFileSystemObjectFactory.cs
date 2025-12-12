using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectFactories;

public interface IFileSystemObjectFactory
{
    IFileSystemObject Create(IPath path);
}