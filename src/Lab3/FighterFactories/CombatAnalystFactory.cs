using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterFactories;

public class CombatAnalystFactory : IFighterFactory
{
    public IBuilder Create()
    {
        return new CombatAnalyst.CombatAnalystBuilderDefaultDirector()
            .Direct(new CombatAnalyst.CombatAnalystBuilder());
    }
}