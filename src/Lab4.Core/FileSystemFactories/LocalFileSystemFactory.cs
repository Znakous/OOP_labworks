using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemImpls;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;

public class LocalFileSystemFactory : IFileSystemImplFactory
{
    public IFileSystemImpl Create()
    {
        return new LocalFileSystemImpl();
    }
}