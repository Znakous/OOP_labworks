using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemImpls;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;

public class LocalFileSystemFactory : IFileSystemImplFactory
{
    private readonly IPathHandler _pathHandler;

    public LocalFileSystemFactory(IPathHandler pathHandler)
    {
        _pathHandler = pathHandler;
    }

    public IFileSystemImpl Create()
    {
        return new LocalFileSystemImpl(_pathHandler);
    }
}