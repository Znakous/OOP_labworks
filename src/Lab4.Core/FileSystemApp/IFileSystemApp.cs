using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApp;

public interface IFileSystemApp
{
    bool TryConnect(IPath root);

    void Disconnect();

    IFileSystem FileSystem { get; }
}