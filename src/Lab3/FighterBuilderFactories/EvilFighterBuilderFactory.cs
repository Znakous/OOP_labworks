using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class EvilFighterBuilderFactory : IFighterBuilderFactory
{
    public IEditableFighterBuilder Create()
    {
        return new EvilFighter.EvilFighterBuilderDefaultDirector()
            .Direct(new EvilFighter.EvilFighterEditableFighterBuilder());
    }
}