using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;

public interface IFileSystemFactory
{
    FileSystemCreateResult Create(IPath path);
}