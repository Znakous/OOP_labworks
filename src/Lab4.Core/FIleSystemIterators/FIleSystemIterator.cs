using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FIleSystemIterators;

public class FIleSystemIterator : IFileSystemIterator
{
    private readonly IFileSystem _fileSystem;

    private readonly IFileSystemObjectFactory _objectFactory;

    private IPath _currentPath;

    public FIleSystemIterator(IPath path, IFileSystem fileSystem, IFileSystemObjectFactory objectFactory)
    {
        _currentPath = path;
        _fileSystem = fileSystem;
        _objectFactory = objectFactory;
    }

    public IFileSystemObject Current()
    {
        return _objectFactory.Create(_currentPath);
    }

    public bool MoveTo(IPath newPath)
    {
        _currentPath = newPath;
        return _fileSystem.Exists(_currentPath);
    }
}