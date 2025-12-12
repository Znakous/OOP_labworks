using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Paths.PathHandlers;

public class StrategicHandlerModifier : IPathHandler
{
    private readonly IPathHandler _handler;
    private readonly IPathMatchingStrategy _strategy;

    public StrategicHandlerModifier(IPathHandler handler, IPathMatchingStrategy strategy)
    {
        _handler = handler;
        _strategy = strategy;
    }

    public string MakePath(IPath path)
    {
        return _handler.MakePath(path);
    }

    public IPath ParsePath(string pathString)
    {
        return _strategy.MatchPath(_handler.ParsePath(pathString));
    }
}