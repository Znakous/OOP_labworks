using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApp;

public class FileSystemApp : IFileSystemApp
{
    private readonly IFileSystemFactory _fileSystemFactory;

    public IFileSystem FileSystem { get; private set; }

    public FileSystemApp(IFileSystemFactory fileSystemFactory)
    {
        _fileSystemFactory = fileSystemFactory;
        FileSystem = new DisconnectedFileSystem();
    }

    public void Connect(IPath root)
    {
        FileSystem = _fileSystemFactory.Create(root);
    }

    public void Disconnect()
    {
        FileSystem = new DisconnectedFileSystem();
    }
}