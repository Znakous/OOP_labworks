using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;

public interface IFileSystemObjectVisitor
{
    void Visit(DirectoryObject directory);

    void Visit(FileObject file);
}