using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class DisconnectedFileSystem : IFileSystem
{
    public void CopyFile(IPath sourcePath, IPath targetPath) { }

    public void MoveFile(IPath sourcePath, IPath targetPath) { }

    public void DeleteFile(IPath targetPath) { }

    public bool IsDirectory(IPath path) => false;

    public bool Exists(IPath path) => true;

    public IEnumerable<IPath> GetDirectoryContents(IPath path) => [];

    public string GetFileContent(IPath path) => string.Empty;
}