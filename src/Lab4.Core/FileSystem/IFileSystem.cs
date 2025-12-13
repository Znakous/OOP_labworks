using Itmo.ObjectOrientedProgramming.Lab4.Core.PathHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public interface IFileSystem
{
    FileSystemInteractionResult CopyFile(IPath sourcePath, IPath targetPath);

    FileSystemInteractionResult MoveFile(IPath sourcePath, IPath targetPath);

    FileSystemInteractionResult DeleteFile(IPath targetPath);

    FileSystemInteractionResult RenameFile(IPath path, string newName);

    bool IsDirectory(IPath path);

    bool Exists(IPath path);

    IEnumerable<IPath> GetDirectoryContents(IPath path);

    GetFileContentResult GetFileContent(IPath path);

    GetIteratorResult GetIterator();

    IPathHandler GetPathHandler();
}