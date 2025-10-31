using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterFactories;

public class EvilFighterFactory : IFighterFactory
{
    public IBuilder Create()
    {
        return new EvilFighter.EvilFighterBuilderDefaultDirector()
            .Direct(new EvilFighter.EvilFighterBuilder());
    }
}