using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemApps;

public interface IFileSystemContext
{
    IPath ConnectionPath { get; set; }

    IPath CurrentPath { get; set; }

    IFileSystem FileSystem { get; set; }

    PathParser PathParser { get; }
}