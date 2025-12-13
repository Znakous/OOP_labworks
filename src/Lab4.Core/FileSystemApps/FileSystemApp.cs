using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApps;

public class FileSystemApp : IFileSystemApp
{
    public IFileSystem FileSystem { get; private set; }

    public FileSystemApp()
    {
        FileSystem = new DisconnectedFileSystem();
    }

    public void Connect(IPath root, IFileSystemImplFactory factory)
    {
        FileSystem = new WorkingFileSystem(factory.Create(), root);
    }

    public void Disconnect()
    {
        FileSystem = new DisconnectedFileSystem();
    }
}