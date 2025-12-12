using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;

public interface IFileSystemObject
{
    string Name { get; }

    IPath Path { get; }

    bool Accept(IFileSystemObjectVisitor visitor);
}