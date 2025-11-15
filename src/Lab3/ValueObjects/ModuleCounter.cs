namespace Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

public class ModuleCounter : IIndexer
{
    private int _mod;

    public int Value { get; private set; }

    public ModuleCounter(int module)
    {
        if (module < 0)
        {
            throw new ArgumentException("Module must not be negative for module counter");
        }

        _mod = module;
        Value = 0;
    }

    public ModuleCounter()
    {
        Value = 0;
        _mod = 1;
    }

    public void Increment()
    {
        Value++;
        Value %= _mod;
    }

    public void ChangeModule(int newModule)
    {
        _mod = newModule;
    }
}