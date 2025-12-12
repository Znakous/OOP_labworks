using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemImpls;

public class LocalFileSystemImpl : IFileSystemImpl
{
    public FileSystemInteractionResult CopyFile(string source, string destination)
    {
        throw new NotImplementedException();
    }

    public FileSystemInteractionResult MoveFile(string source, string destination)
    {
        throw new NotImplementedException();
    }

    public FileSystemInteractionResult DeleteFile(string path)
    {
        throw new NotImplementedException();
    }

    public bool IsDirectory(string path)
    {
        throw new NotImplementedException();
    }

    public bool Exists(string path)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<string> GetDirectoryContents(string path)
    {
        throw new NotImplementedException();
    }
}