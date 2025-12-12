using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjects;

public class FileObject : IFileSystemObject
{
    public IPath Path { get; }

    public FileObject(IPath path)
    {
        Path = path;
    }

    public string Name => Path.Name;

    public bool Accept(IFileSystemObjectVisitor visitor)
    {
        return visitor.Visit(this);
    }
}