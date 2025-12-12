namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

public class Path : IPath
{
    public IEnumerable<string> AsSegments { get; private set; }

    public Path(IEnumerable<string> segments)
    {
        AsSegments = segments;
    }

    public IPath ExtendedWith(IPath path)
    {
        var segments = AsSegments.Concat(path.AsSegments).ToList();
        return new Path(segments);
    }

    public string Name => AsSegments.Last();

    public IPath Renamed(string newName)
    {
        IEnumerable<string> droppedLast = AsSegments.SkipLast(1);
        IEnumerable<string> addedNew = AsSegments.Concat([newName]);
        return new Path(addedNew);
    }
}