using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemImpls;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FIleSystemIterators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.PathHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class WorkingFileSystem : IFileSystem
{
    private readonly IFileSystemImpl _fileSystemImpl;

    private readonly IPathHandler _pathHandler;

    private readonly IPath _root;

    public WorkingFileSystem(IFileSystemImpl fileSystemImpl, IPathHandler pathHandler, IPath root)
    {
        _fileSystemImpl = fileSystemImpl;
        _pathHandler = pathHandler;
        _root = root;
    }

    public FileSystemInteractionResult CopyFile(IPath sourcePath, IPath targetPath)
    {
        return _fileSystemImpl.CopyFile(GetPathString(sourcePath), GetPathString(targetPath));
    }

    public FileSystemInteractionResult MoveFile(IPath sourcePath, IPath targetPath)
    {
        return _fileSystemImpl.MoveFile(
            GetPathString(sourcePath),
            GetPathString(targetPath));
    }

    public FileSystemInteractionResult DeleteFile(IPath targetPath)
    {
        return _fileSystemImpl.DeleteFile(GetPathString(targetPath));
    }

    public FileSystemInteractionResult RenameFile(IPath path, string newName)
    {
        return _fileSystemImpl.MoveFile(
            GetPathString(path),
            GetPathString(path.Renamed(newName)));
    }

    public GetIteratorResult GetIterator(IPath path)
    {
        return new GetIteratorResult.Success(new FIleSystemIterator(_root, this, new DirectoryAwareFileSystemObjectFactory(this)));
    }

    public IEnumerable<IPath> GetDirectoryContents(IPath path)
    {
        IEnumerable<string> contents = _fileSystemImpl.GetDirectoryContents(GetPathString(path));

        return contents.Select(x => ParsePath(x));
    }

    public bool IsDirectory(IPath path)
    {
        return _fileSystemImpl.IsDirectory(GetPathString(path));
    }

    public bool Exists(IPath path)
    {
        return _fileSystemImpl.Exists(GetPathString(path));
    }

    private string GetPathString(IPath path)
    {
        return _pathHandler.MakePath(path);
    }

    private IPath ParsePath(string path)
    {
        return _pathHandler.ParsePath(path);
    }
}