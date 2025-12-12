using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

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

    public bool TryConnect(IPath root)
    {
        if (_fileSystemFactory.Create(root) is FileSystemCreateResult.Success success)
        {
            FileSystem = success.FileSystem;
            return true;
        }

        return false;
    }

    public void Disconnect()
    {
        FileSystem = new DisconnectedFileSystem();
    }
}