using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class CombatAnalystBuilderFactory : IFighterBuilderFactory
{
    public IFighterOnTableBuilder Create()
    {
        return CombatAnalyst.DefaultBuilder;
    }
}