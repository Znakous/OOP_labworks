using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathValidators;

public class FileSystemPathValidator : IPathValidator
{
    private readonly IFileSystem _fileSystem;

    public FileSystemPathValidator(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public bool IsValidPath(IPath path)
    {
        return _fileSystem.Exists(path);
    }

    public bool IsDirectory(IPath path)
    {
        return _fileSystem.IsDirectory(path);
    }
}