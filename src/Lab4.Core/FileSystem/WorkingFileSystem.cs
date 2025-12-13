using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemImpls;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FIleSystemIterators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemObjectFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.PathHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathValidators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class WorkingFileSystem : IFileSystem
{
    private readonly IFileSystemImpl _fileSystemImpl;

    private readonly StrategicHandlerModifier _pathHandler;

    private readonly IPath _root;

    private readonly FIleSystemIterator _iterator;

    public WorkingFileSystem(IFileSystemImpl fileSystemImpl, IPath root)
    {
        _fileSystemImpl = fileSystemImpl;
        _root = root;
        _iterator = new FIleSystemIterator(_root, this, new DirectoryAwareFileSystemObjectFactory(this));
        _pathHandler = new StrategicHandlerModifier(
            fileSystemImpl.PathHandler,
            new RelativePriorityStrategy(_iterator.Path, new FileSystemPathValidator(this)));
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

    public GetIteratorResult GetIterator()
    {
        return new GetIteratorResult.Success(_iterator);
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

    public GetFileContentResult GetFileContent(IPath path)
    {
        if (!Exists(path))
        {
            return new GetFileContentResult.Failure(
                new PerformedOperationOnNonExistentFile(
                    "Couldn't perform GetContent on file that doesn't exist"));
        }

        return new GetFileContentResult.Success(_fileSystemImpl.GetFileContent(GetPathString(path)));
    }

    public IPathHandler GetPathHandler()
    {
        return _pathHandler;
    }

    private string GetPathString(IPath path)
    {
        return _pathHandler.MakePath(_root.ExtendedWith(path));
    }

    private IPath ParsePath(string path)
    {
        return _root.ExtendedWith(_pathHandler.ParsePath(path));
    }
}