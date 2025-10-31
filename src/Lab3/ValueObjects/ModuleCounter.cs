namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public class ModuleCounter
{
    private readonly int _module;

    public int Value { get; private set; }

    public ModuleCounter(int module)
    {
        if (module <= 0)
        {
            throw new ArgumentException("Module must be positive for module counter");
        }

        _module = module;
        Value = 0;
    }

    public static ModuleCounter operator ++(ModuleCounter counter)
    {
        counter.Value++;
        if (counter.Value >= counter._module)
        {
            counter.Value = 0;
        }

        return counter;
    }
}