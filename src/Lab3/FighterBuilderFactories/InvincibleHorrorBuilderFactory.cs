using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class InvincibleHorrorBuilderFactory : IFighterBuilderFactory
{
    public IEditableFighterBuilder Create()
    {
        return new InvincibleHorror.InvincibleHorrorBuilderDefaultDirector()
            .Direct(new InvincibleHorror.InvincibleHorrorEditableFighterBuilder());
    }
}