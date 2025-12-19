using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsers;

public interface IPathParser
{
    IPath ParsePath(string pathString, IPathMatchingStrategy inputStrategy);
}