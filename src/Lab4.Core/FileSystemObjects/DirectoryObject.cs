using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;

public class DirectoryObject : IFileSystemObject
{
    public IPath Path { get; }

    public IReadOnlyList<IFileSystemObject> Contents { get; }

    public DirectoryObject(IReadOnlyList<IFileSystemObject> contents, IPath path)
    {
        Contents = contents;
        Path = path;
    }

    public string Name => Path.Name;

    public bool Accept(IFileSystemObjectVisitor visitor)
    {
        return visitor.Visit(this);
    }
}