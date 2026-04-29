using Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathCreators;

public interface IPathCreator
{
    string BuildPath(IPath path, IPathMatchingStrategy strategy);
}