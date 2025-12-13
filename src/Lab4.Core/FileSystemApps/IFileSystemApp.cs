using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApps;

public interface IFileSystemApp
{
    void Connect(IPath root, IFileSystemImplFactory factory);

    void Disconnect();

    IFileSystem FileSystem { get; }
}