namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public class ContinuousSelector : ISelector
{
    public IFighter? GetNextFighter(IEnumerable<IFighter> fighters)
    {
        return fighters.FirstOrDefault();
    }
}