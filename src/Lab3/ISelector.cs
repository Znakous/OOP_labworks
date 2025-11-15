namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface ISelector
{
    IFighter? GetNextFighter(IEnumerable<IFighter> fighters);
}