using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.PathHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class DisconnectedFileSystem : IFileSystem
{
    public FileSystemInteractionResult CopyFile(IPath sourcePath, IPath targetPath)
    {
        return new FileSystemInteractionResult.Failure(
            new DisconnectedSystemInteraction("called CopyFile on disconnected system"));
    }

    public FileSystemInteractionResult MoveFile(IPath sourcePath, IPath targetPath)
    {
        return new FileSystemInteractionResult.Failure(
            new DisconnectedSystemInteraction("called MoveFile on disconnected system"));
    }

    public FileSystemInteractionResult DeleteFile(IPath targetPath)
    {
        return new FileSystemInteractionResult.Failure(
            new DisconnectedSystemInteraction("called DeleteFile on disconnected system"));
    }

    public FileSystemInteractionResult RenameFile(IPath path, string newName)
    {
        return new FileSystemInteractionResult.Failure(
            new DisconnectedSystemInteraction("called RenameFile on disconnected system"));
    }

    public GetIteratorResult GetIterator()
    {
        return new GetIteratorResult.Failure(
            new DisconnectedSystemInteraction("can't get iterator from disconnected system"));
    }

    public bool IsDirectory(IPath path)
    {
        return false;
    }

    public bool Exists(IPath path)
    {
        return false;
    }

    public IEnumerable<IPath> GetDirectoryContents(IPath path)
    {
        return [];
    }

    public IPathHandler GetPathHandler()
    {
        return new UnixPathHandler();
    }

    public GetFileContentResult GetFileContent(IPath path)
    {
        return new GetFileContentResult.Failure(
            new DisconnectedSystemInteraction("called GetFileContent on disconnected system"));
    }
}