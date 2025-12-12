using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FIleSystemIterators;

public class FIleSystemIterator : IFileSystemIterator
{
    private readonly IFileSystem _fileSystem;

    private readonly IFileSystemObjectFactory _objectFactory;

    public IPath Path { get; private set; }

    public FIleSystemIterator(IPath path, IFileSystem fileSystem, IFileSystemObjectFactory objectFactory)
    {
        Path = path;
        _fileSystem = fileSystem;
        _objectFactory = objectFactory;
    }

    public IFileSystemObject Current()
    {
        return _objectFactory.Create(Path);
    }

    public bool TryMoveTo(IPath newPath)
    {
        if (_fileSystem.Exists(newPath))
        {
            Path = newPath;
            return true;
        }

        return false;
    }
}