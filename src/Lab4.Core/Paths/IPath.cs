namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

public interface IPath
{
    IPath ExtendedWith(IPath path);

    IPath Renamed(string newName);

    string Name { get; }

    IEnumerable<string> AsSegments { get; }
}