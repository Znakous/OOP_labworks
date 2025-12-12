using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectFactories;

public class DirectoryAwareFileSystemObjectFactory : IFileSystemObjectFactory
{
    private readonly IFileSystem _fileSystem;

    public DirectoryAwareFileSystemObjectFactory(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public IFileSystemObject Create(IPath path)
    {
        if (_fileSystem.IsDirectory(path))
        {
            var fileSystemObjects = new List<IFileSystemObject>();
            foreach (IPath contentPath in _fileSystem.GetDirectoryContents(path))
            {
                Create(contentPath);
            }

            return new DirectoryObject(fileSystemObjects, path);
        }

        return new FileObject(path);
    }
}