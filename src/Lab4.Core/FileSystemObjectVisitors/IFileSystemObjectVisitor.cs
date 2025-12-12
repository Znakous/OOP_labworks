using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;

public interface IFileSystemObjectVisitor
{
    bool Visit(DirectoryObject directory);

    bool Visit(FileObject file);
}