using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemImpls;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;

public class WorkingFileSystemFactory : IFileSystemFactory
{
    private readonly IFileSystemImpl _fileSystemImpl;

    public WorkingFileSystemFactory(IFileSystemImpl fileSystemImpl)
    {
        _fileSystemImpl = fileSystemImpl;
    }

    public IFileSystem Create(IPath path)
    {
        return new WorkingFileSystem(_fileSystemImpl, path);
    }
}