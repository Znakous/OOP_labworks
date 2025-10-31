using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterFactories;

public class InvincibleHorrorFactory : IFighterFactory
{
    public IBuilder Create()
    {
        return new InvincibleHorror.InvincibleHorrorBuilderDefaultDirector()
            .Direct(new InvincibleHorror.InvincibleHorrorBuilder());
    }
}