using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class EvilFighterBuilderFactory : IFighterBuilderFactory
{
    public IFighterOnTableBuilder Create()
    {
        return EvilFighter.DefaultBuilder;
    }
}