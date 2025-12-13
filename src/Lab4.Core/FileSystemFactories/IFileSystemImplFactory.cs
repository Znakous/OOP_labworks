using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemImpls;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;

public interface IFileSystemImplFactory
{
    IFileSystemImpl Create();
}