using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemImpls;

public interface IFileSystemImpl
{
    FileSystemInteractionResult CopyFile(string source, string destination);

    FileSystemInteractionResult MoveFile(string source, string destination);

    FileSystemInteractionResult DeleteFile(string path);

    bool IsDirectory(string path);

    bool Exists(string path);

    IReadOnlyList<string> GetDirectoryContents(string path);
}