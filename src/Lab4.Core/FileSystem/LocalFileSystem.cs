using Itmo.ObjectOrientedProgramming.Lab4.Core.PathBuildingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathCreators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;

public class LocalFileSystem : IFileSystem
{
    private readonly AbsolutePathCreator _pathCreator;

    private readonly PathParser _pathParser;

    public LocalFileSystem(IPathBuildingStrategy strategy)
    {
        _pathCreator = new AbsolutePathCreator(strategy);
        _pathParser = new PathParser(strategy);
    }

    public void CopyFile(IPath sourcePath, IPath targetPath)
    {
        File.Copy(PathToString(sourcePath), PathToString(targetPath));
    }

    public void MoveFile(IPath sourcePath, IPath targetPath)
    {
        File.Move(PathToString(sourcePath), PathToString(targetPath));
    }

    public void DeleteFile(IPath targetPath)
    {
        File.Delete(PathToString(targetPath));
    }

    public IEnumerable<IPath> GetDirectoryContents(IPath path)
    {
        return Directory.GetFileSystemEntries(PathToString(path))
            .Select(x => StringToPath(x)).ToList();
    }

    public bool IsDirectory(IPath path)
    {
        return Directory.Exists(PathToString(path));
    }

    public bool Exists(IPath path)
    {
        return File.Exists(PathToString(path)) || Directory.Exists(PathToString(path));
    }

    public string GetFileContent(IPath path)
    {
        return File.ReadAllText(PathToString(path));
    }

    private string PathToString(IPath path)
    {
        return _pathCreator.BuildPath(path, new AbsoluteOnlyStrategy());
    }

    private IPath StringToPath(string path)
    {
        return _pathParser.ParsePath(path, new AbsoluteOnlyStrategy());
    }
}