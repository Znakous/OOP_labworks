using Itmo.ObjectOrientedProgramming.Lab4.Core.Paths;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.PathParsingStrategies;

public abstract class RelativeStrategyBase : IPathMatchingStrategy
{
    public abstract IPath CreatePath(IEnumerable<string> pathSegments);

    public abstract IEnumerable<string> GetPathSegments(IPath path);

    protected IEnumerable<string> GetAfterCommonPrefix(IEnumerable<string> sequence1, IEnumerable<string> sequence2)
    {
        IEnumerator<string> enumerator1 = sequence1.GetEnumerator();
        IEnumerator<string> enumerator2 = sequence2.GetEnumerator();

        int commonPrefixLength = 0;
        while (enumerator1.MoveNext() && enumerator2.MoveNext())
        {
            if (enumerator1.Current != enumerator2.Current)
                break;
            commonPrefixLength++;
        }

        IEnumerable<string> afterInFirst = sequence1.Skip(commonPrefixLength);
        return afterInFirst;
    }
}