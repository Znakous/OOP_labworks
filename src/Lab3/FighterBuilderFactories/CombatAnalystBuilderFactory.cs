using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class CombatAnalystBuilderFactory : IFighterBuilderFactory
{
    public IEditableFighterBuilder Create()
    {
        return new CombatAnalyst.CombatAnalystBuilderDefaultDirector()
            .Direct(new CombatAnalyst.CombatAnalystEditableFighterBuilder());
    }
}