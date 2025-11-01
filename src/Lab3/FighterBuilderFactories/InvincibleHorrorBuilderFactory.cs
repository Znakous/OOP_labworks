using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class InvincibleHorrorBuilderFactory : IFighterBuilderFactory
{
    public IFighterOnTableBuilder Create()
    {
        return InvincibleHorror.DefaultBuilder;
    }
}