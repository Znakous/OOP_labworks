using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystem
{
    void CopyFile(IPath sourcePath, IPath targetPath);

    void MoveFile(IPath sourcePath, IPath targetPath);

    void DeleteFile(IPath targetPath);

    bool IsDirectory(IPath path);

    bool Exists(IPath path);

    IEnumerable<IPath> GetDirectoryContents(IPath path);

    string GetFileContent(IPath path);
}