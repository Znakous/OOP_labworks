using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;

public class FileObject : IFileSystemObject
{
    private readonly IPath _path;

    public FileObject(IPath path)
    {
        _path = path;
    }

    public string Name => _path.Name;

    public void Accept(IFileSystemObjectVisitor visitor)
    {
        visitor.Visit(this);
    }
}