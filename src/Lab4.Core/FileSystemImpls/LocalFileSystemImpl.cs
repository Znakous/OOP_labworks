using Itmo.ObjectOrientedProgramming.Lab4.Core.PathHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemImpls;

public class LocalFileSystemImpl : IFileSystemImpl
{
    public IPathHandler PathHandler { get; }

    public LocalFileSystemImpl(IPathHandler pathHandler)
    {
        PathHandler = pathHandler;
    }

    public FileSystemInteractionResult CopyFile(string source, string destination)
    {
        File.Copy(source, destination);
        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult MoveFile(string source, string destination)
    {
        File.Move(source, destination);
        return new FileSystemInteractionResult.Success();
    }

    public FileSystemInteractionResult DeleteFile(string path)
    {
        File.Delete(path);
        return new FileSystemInteractionResult.Success();
    }

    public bool IsDirectory(string path)
    {
        return Directory.Exists(path);
    }

    public bool Exists(string path)
    {
        return File.Exists(path) || Directory.Exists(path);
    }

    public IReadOnlyList<string> GetDirectoryContents(string path)
    {
        return Directory.GetFileSystemEntries(path);
    }

    public string GetFileContent(string path)
    {
        return File.ReadAllText(path);
    }
}