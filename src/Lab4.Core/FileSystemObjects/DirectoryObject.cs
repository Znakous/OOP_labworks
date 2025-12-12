using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;

public class DirectoryObject : IFileSystemObject
{
    private readonly IPath _path;

    public IReadOnlyList<IFileSystemObject> Contents { get; }

    public DirectoryObject(IReadOnlyList<IFileSystemObject> contents, IPath path)
    {
        Contents = contents;
        _path = path;
    }

    public string Name => _path.Name;

    public void Accept(IFileSystemObjectVisitor visitor)
    {
        visitor.Visit(this);
    }
}