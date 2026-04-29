using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Path = Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.Path;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemContexts;

public class FileSystemContext : IFileSystemContext
{
    public IFileSystem FileSystem { get; set; }

    public PathParser PathParser { get; }

    public IPath ConnectionPath { get; set; }

    public IPath CurrentPath { get; set; }

    public FileSystemContext(PathParser pathParser)
    {
        FileSystem = new DisconnectedFileSystem();
        ConnectionPath = new Path([]);
        CurrentPath = new Path([]);
        PathParser = pathParser;
    }

    public bool TryConnect(IPath root, IFileSystem fileSystem)
    {
        if (!fileSystem.Exists(root))
        {
            return false;
        }

        FileSystem = fileSystem;
        return true;
    }

    public bool IsConnected()
    {
        return FileSystem is not DisconnectedFileSystem;
    }

    public void Disconnect()
    {
        FileSystem = new DisconnectedFileSystem();
    }
}