using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;

public interface IFileSystemObject
{
    string Name { get; }

    void Accept(IFileSystemObjectVisitor visitor);
}